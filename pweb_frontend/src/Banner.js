/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React, { useEffect, useState, useCallback } from 'react'
import './App.css'
import { Routes, Route, Link, useNavigate } from 'react-router-dom'
import logo from './logo.png'
import pfp_default from './pfp_default.jpg'
import { useAuth0 } from '@auth0/auth0-react'
import axios from 'axios'
import {base, routes} from './Api'

// Cata99*

const Banner = (props) => {
  const { idToken, setIdToken } = props
  const { logout, user, getAccessTokenSilently, getIdTokenClaims } = useAuth0()
  const [userMetadata, setUserMetadata] = useState(null)
  const [profile, setProfile] = useState(false)
  const [profData, setProfData] = useState({})
  const [auxData, setAuxData] = useState({})
  const navigate = useNavigate()
  // useEffect(() => {
  //     const getUserMetadata = async () => {
  //       const domain = "dev-rxvajvsu.us.auth0.com";

  //       try {
  //         const accessToken = await getAccessTokenSilently({
  //           audience: `https://${domain}/api/v2/`,
  //           scope: "read:current_user",
  //         });

  //         const userDetailsByIdUrl = `https://${domain}/api/v2/users/${user.sub}`;
  //         console.log(accessToken);
  //         const metadataResponse = await fetch(userDetailsByIdUrl, {
  //           headers: {
  //             Authorization: `Bearer ${accessToken}`,
  //           },
  //         });

  //         const { user_metadata } = await metadataResponse.json();
  //         if (accessToken) {
  //             console.log('ok')
  //         }
  //         setUserMetadata(user_metadata);
  //       } catch (e) {
  //         console.log(e.message);
  //       }
  //     };
  //     getUserMetadata();
  //   }, [getAccessTokenSilently, user?.sub]);
  const axiosInstance = axios.create({
    baseURL: 'http://localhost:5000/',
    // timeout: 1000,
  });
  // useEffect(() => {
  //   if (idToken) {
  //     // console.log(idToken)
        const get = () => {
          (async () => {
            const role = idToken['https://PetAway.com/role']
            const accessToken = await getAccessTokenSilently();
            //console.log(accessToken)
            axiosInstance
              .get(routes[role]['get' + role], {
                headers: {
                  Authorization: `Bearer ${accessToken}`,
                },
              })
              .then(({data}) => {
                //console.log(data)
                //console.log('hau')
                setProfData(data)
              })
          })();
        }     
        // console.log(idToken)
  //       get()
  //   }
  // }, [idToken])
  // useEffect((
  //   get_profile()
  // ), [get_profile])
  get()
  return (<>
        <header className="App-banner">
            <button className = "BannerButton" onClick={() => logout({ returnTo: window.location.origin })}>
              <header className="ButtonText">Log out</header>
            </button>
            {/* <a href="https://www.youtube.com/watch?v=tPKq8ffzMFY" target="_blank" rel="noreferrer"> */}
            <button className = "BannerButton Donate" onClick = {() => {}}>
              <header className="ButtonText">Donate</header>
            </button>
            {/* </a> */}
            {/* <Link to="home"> */}
            <img className = "App-lil-logo" src={logo} alt="Logo" onClick={() => { navigate('/home') }}/>
            {/* </Link> */}
            <img className = "App-profile-pic" src={profData.photoPath ? profData.photoPath : pfp_default} onClick = {() => {//get();
              setProfile(!profile);
              //console.log(profData)
              //auxData = JSON.parse(JSON.stringify(profData));
              //console.log(auxData)
              setAuxData(profData)
            }}
            />
        </header>
        {profile && <div className = 'App-profile-div' on>
          <img className = "img-responsive App-profile-pic-detail" src={auxData.photoPath ? auxData.photoPath : pfp_default} onError = {(ev) => {ev.target.src=pfp_default}}></img>
          <div className='App-profile-label App-email-label'>Email</div>
          <input className='App-profile-input App-email-form' value = {auxData.email} />
          <div className='App-profile-label'>Name</div>
          <input type="text" className='App-profile-input' value = {auxData.name} onChange={(e) => auxData['name'] = e.target.value}/>
          <div className='App-profile-label'>Phone number</div>
          <input type="tel" className='App-profile-input' value = {auxData.phoneNumber} onChange={(e) => auxData['phoneNumber'] = e.target.value} pattern="[0-9]{10}"/>
          <div className='App-profile-label'>Address</div>
          <input type="text" className='App-profile-input' value = {auxData.address} onChange={(e) => auxData['address'] = e.target.value}/>
          <div className='App-profile-label'>Profile picture URL</div>
          <input type="text" className='App-profile-input' value = {auxData.photoPath} onChange={(e) => auxData['photoPath'] = e.target.value}/>
          {auxData.maxCapacity && <div className='App-profile-label'>Max capacity</div>}
          {auxData.maxCapacity && <input type="number" className='App-profile-input' value = {auxData.maxCapacity} onChange={(e) => auxData['maxCapacity'] = e.target.value}/>}
          <button className = "BannerButton Profile-submit" onClick = {() => {
                  (async () => {
                    const role = idToken['https://PetAway.com/role']
                    const accessToken = await getAccessTokenSilently();
                    // console.log(accessToken)
                    axiosInstance
                      .put(routes[role]['add' + role], auxData, {
                        headers: {
                          Authorization: `Bearer ${accessToken}`,
                        },
                      })
                      .then(() => {});
                  })();
                  setProfile(!profile)
                }}>
              <header className="ButtonText White-btn">Submit</header>
          </button>
        </div>}      
  </>)
}

export default Banner
