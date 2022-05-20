import React, { useEffect, useState } from "react";
import './App.css';
import { Routes, Route, Link, useNavigate } from "react-router-dom";
import logo from './logo.png';
import { useAuth0 } from "@auth0/auth0-react";

// Cata99*

const Banner = (props) => {
    const { idToken } = props;
    const {logout, user, getAccessTokenSilently, getIdTokenClaims} = useAuth0();
    const [userMetadata, setUserMetadata] = useState(null);
    const navigate = useNavigate();
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

    return (
        <header className="App-banner">
            <button className = "BannerButton" onClick={() => logout({ returnTo: window.location.origin })}>
              <header className="ButtonText">Log out</header>
            </button>
            {/* <a href="https://www.youtube.com/watch?v=tPKq8ffzMFY" target="_blank" rel="noreferrer"> */}
            <button className = "BannerButton Donate" onClick = {() => {console.log(idToken)}}>
              <header className="ButtonText">Donate</header>
            </button>
            {/* </a> */}
            {/* <Link to="home"> */}
            <img className = "App-lil-logo" src={logo} alt="Logo" onClick={() => {navigate('/home')}}/>
            {/* </Link> */}
            <img className = "App-profile-pic" src={idToken?idToken['picture']:logo}/>
        </header>
    );
}

export default Banner;