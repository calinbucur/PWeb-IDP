/* eslint-disable no-unused-vars */
import './App.css'
import React, { useEffect, useState } from 'react'
import LoginButton from './LoginButton'
import { Routes, Route, Link, useNavigate } from 'react-router-dom'
import logo from './logo.png'
import { useAuth0 } from '@auth0/auth0-react'
import './BannerButton.css'
import LogoutPage from './LogoutPage'
import Banner from './Banner'
import Feed from './Feed'
import {base, routes} from './Api'
import axios from 'axios'

function Home () {
  return (
    <>
      <main>
        <h2>Welcome to the homepage!</h2>
        <p>You can do this, I believe in you.</p>
      </main>
      <nav>
        <Link to="/home">About</Link>
      </nav>
    </>
  )
}

function About () {
  return (
    <>
      <main>
        <h2>Who are we?</h2>
        <p>
          That feels like an existential question, don`&apos;`t you
          think?
        </p>
      </main>
      <nav>
        <Link to="/">Home</Link>
      </nav>
    </>
  )
}

function App () {
  const { isAuthenticated, loginWithRedirect, logout, getIdTokenClaims, getAccessTokenSilently } = useAuth0()

  // let app = () => {
  //   return <div className="App">
  //     <header className="App-banner">
  //       <header className="App-title">
  //         PetAway
  //       </header>
  //       <button className = "BannerButton" onClick={() => loginWithRedirect()}>
  //         <header className="ButtonText">Sign in</header>
  //       </button>
  //       {/* <img src={logo} alt="Logo" /> */}
  //     </header>
  //     <img className = "App-big-logo" src={logo} alt="Logo"/>
  //   </div>
  // }
  const [idToken, setIdToken] = useState(undefined)
  const getToken = async () => {
    const claims = await getIdTokenClaims()
    setIdToken(claims)
    // console.log('GOT CLAIMS')
    // return claims;
  }
  // getRole().catch()
  // console.log(test)
  const axiosInstance = axios.create({
    baseURL: base,
  });
  const navigate = useNavigate()
  useEffect(() => {
    if (isAuthenticated) {
      getToken().then(() => {
      // console.log(idToken)
        const role = idToken['https://PetAway.com/role']
        let post_obj = {
          "email": idToken.email,
          "name": "",
          "phoneNumber": "",
          "address": "",
          "photoPath": ""
        }
        if (role === 'foster') {
          post_obj['maxCapacity'] = 0
          post_obj['crtCapacity'] = 0
        }
        const post = () => {
          (async () => {
            const accessToken = await getAccessTokenSilently();
            // console.log(accessToken)
            axiosInstance
              .post(routes[role]['add' + role], post_obj, {
                headers: {
                  Authorization: `Bearer ${accessToken}`,
                },
              })
              .then(() => {});
          })();
        }
        const get = () => {
          (async () => {
            const accessToken = await getAccessTokenSilently();
            // console.log(accessToken)
            axiosInstance
              .get(routes[role]['get' + role], {
                headers: {
                  Authorization: `Bearer ${accessToken}`,
                },
              })
              .then(() => {}).catch(post);
          })();
        }
        // console.log(idToken)
        get()
      })
      navigate('/home')
    }
  }, [isAuthenticated, navigate, idToken])
  return (
    <div className='App'>
      <Routes>
        <Route path="/" element={
          <LogoutPage></LogoutPage>
        } />
        <Route path="/home" element={<>
          <header className = "App-side-prompt">
            Hey {idToken ? idToken['https://PetAway.com/role'] : ''}
          </header>
          <Banner idToken = {idToken} setIdToken = {setIdToken}></Banner>
          <Feed></Feed>
          
        </>} />
      </Routes>
    </div>
  )
  // useEffect(() => {
  // if (!isAuthenticated) {
  //   // return (
  //   //   <div className="App">
  //   //     <header className="App-banner">
  //   //       <header className="App-title">
  //   //         PetAway
  //   //       </header>
  //   //       <button className = "BannerButton" onClick={() => loginWithRedirect()}>
  //   //         <header className="ButtonText">Sign in</header>
  //   //       </button>
  //   //     </header>
  //   //     <img className = "App-big-logo" src={logo} alt="Logo"/>
  //   //     <header className = "App-side-prompt">
  //   //       Hundreds of pets from Ukraine need your help.
  //   //       <br></br>
  //   //       Sign up to save your pet or help save others.
  //   //     </header>
  //   //   </div>
  //   // );
  //   return (<LogoutPage></LogoutPage>);
  // } else {
  //   return(
  //     <div className="App">
  //       {/* <header className="App-banner">
  //       <img className = "App-lil-logo" src={logo} alt="Logo"/>
  //         <button className = "BannerButton" onClick={() => logout({ returnTo: window.location.origin })}>
  //           <header className="ButtonText">Log out</header>
  //         </button>
  //       </header> */}
  //       <Banner></Banner>
  //       <Feed></Feed>
  //     </div>
  //   );
  // }
  // }, [isAuthenticated, loginWithRedirect]);
  // return app;
  // return (
  //   <div className="App">
  //     <Routes>
  //       <Route path="/" element={<>
  //         <header className="App-banner">
  //           <header className="App-title">
  //             PetAway
  //           </header>
  //           <button className = "BannerButton" onClick={() => loginWithRedirect()}>
  //             <header className="ButtonText">Sign in</header>
  //            </button>
  //           {/* <img src={logo} alt="Logo" /> */}
  //         </header>
  //         <img className = "App-big-logo" src={logo} alt="Logo"/>
  //         <Home />
  //         </>} />
  //       <Route path="/home" element={<><About /></>} />

  //     </Routes>
  //     {/* <header className="App-banner">
  //       <LoginButton></LoginButton>
  //     </header> */}
  //   </div>
  // );
}

export default App
