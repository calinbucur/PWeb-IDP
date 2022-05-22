/* eslint-disable no-unused-vars */
import './App.css'
import React, { useEffect, useState } from 'react'
import { Routes, Route, Link, useNavigate } from 'react-router-dom'
import { useAuth0 } from '@auth0/auth0-react'
import './BannerButton.css'
import LogoutPage from './LogoutPage'
import Banner from './Banner'
import Feed from './Feed'
import {base, routes} from './Api'
import axios from 'axios'

function App () {
  const { isAuthenticated, loginWithRedirect, logout, getIdTokenClaims, getAccessTokenSilently } = useAuth0()
  const [high, setHigh] = useState(null)
  const [high2, setHigh2] = useState(null)
  const [profile, setProfile] = useState(false)
  const [addPet, setAddPet] = useState(false)
  const [idToken, setIdToken] = useState(undefined)
  const getToken = async () => {
    const claims = await getIdTokenClaims()
    setIdToken(claims)
  }
  const axiosInstance = axios.create({
    baseURL: base,
  });
  const navigate = useNavigate()
  useEffect(() => {
    if (isAuthenticated) {
      getToken().then(() => {
        const role = idToken?idToken['https://PetAway.com/role']:''
        let post_obj = {
          "email": idToken?idToken.email:'',
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
            if (role) axiosInstance
              .get(routes[role]['get' + role], {
                headers: {
                  Authorization: `Bearer ${accessToken}`,
                },
              })
              .then(() => {}).catch(post);
          })();
        }
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
          <Banner idToken = {idToken} setIdToken = {setIdToken} high={high} setHigh={setHigh} profile={profile} setProfile={setProfile} addPet={addPet} setAddPet={setAddPet} high2={high2} setHigh2={setHigh2}></Banner>
          <Feed idToken = {idToken} setIdToken = {setIdToken} high={high} setHigh={setHigh} profile={profile} setProfile={setProfile} addPet={addPet} setAddPet={setAddPet} high2={high2} setHigh2={setHigh2}></Feed>
          
        </>} />
      </Routes>
    </div>
  )
}

export default App
