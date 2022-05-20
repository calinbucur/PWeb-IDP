/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react'
import './App.css'
import { Routes, Route, Link, useNavigate } from 'react-router-dom'
import logo from './logo.png'
import { useAuth0 } from '@auth0/auth0-react'
import axios from 'axios'

// Cata99*

const Banner = (props) => {
  const { idToken } = props
  const { logout, user, getAccessTokenSilently, getIdTokenClaims } = useAuth0()
  const [userMetadata, setUserMetadata] = useState(null)
  const [profile, setProfile] = useState(false)
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
    timeout: 1000,
  });
  const post = () => {
    (async () => {
      const accessToken = await getAccessTokenSilently();
      axiosInstance
        .post("/api/v1/Owners/registerOwner", {
          "identityId": "striaffasdang",
          "email": "strifffddng",
          "name": "stridffdng",
          "phoneNumber": "strddffing",
          "address": "stridffdng",
          "photoPath": "stridffdng"
        }, {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(() => console.log(accessToken));
    })();
  }
  return (
        <header className="App-banner">
            <button className = "BannerButton" onClick={() => logout({ returnTo: window.location.origin })}>
              <header className="ButtonText">Log out</header>
            </button>
            {/* <a href="https://www.youtube.com/watch?v=tPKq8ffzMFY" target="_blank" rel="noreferrer"> */}
            <button className = "BannerButton Donate" onClick = {post}>
              <header className="ButtonText">Donate</header>
            </button>
            {/* </a> */}
            {/* <Link to="home"> */}
            <img className = "App-lil-logo" src={logo} alt="Logo" onClick={() => { navigate('/home') }}/>
            {/* </Link> */}
            <img className = "App-profile-pic" src={idToken ? idToken.picture : logo} onClick = {() => setProfile(!profile)}/>
        </header>
  )
}

export default Banner
