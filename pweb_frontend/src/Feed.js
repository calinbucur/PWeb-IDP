/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React, { useEffect, useState, useCallback } from 'react'
import './Feed.css'
import './App.css'
import './BannerButton.css'
import { useAuth0 } from '@auth0/auth0-react'
import axios from 'axios'
import {base, routes} from './Api'
import pet_default from './pet_default.png'

const Feed = (props) => {
  const { idToken, setIdToken } = props;
  const { logout, user, getAccessTokenSilently, getIdTokenClaims } = useAuth0()
  const [profData, setProfData] = useState({})
  const {addPet, setAddPet} = props
  const {high, setHigh} = props
  const {profile, setProfile} = props

  const axiosInstance = axios.create({
    baseURL: base,
    // timeout: 1000,
  });

  const get = () => {
    (async () => {
      const role = idToken?idToken['https://PetAway.com/role']:''
      const accessToken = await getAccessTokenSilently();
      //console.log(accessToken)
      axiosInstance
        .get(routes[role].getanimals, {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(({data}) => {
          console.log(data)
          //console.log('hau')
          setProfData(data)
        })
    })();
  }
  get();
  const objs = []
  // for (let i = 0; i < 20; i++) {
  //   if (i === 4) {
  //     objs.push(<div className = "Feed-item Feed-highlight" key = {i}></div>)
  //   } else { objs.push(<div className = "Feed-item" key = {i}></div>) }
  // }
  for (const key in profData) {
    // console.log(profData[0])
    objs.push(<div className = {high === key?"Feed-item Feed-highlight":"Feed-item"} key = {key} onClick={()=>{
      setAddPet(false)
      setProfile(false)
      if (high === key) {
        setHigh(null)
      }
      else {
        setHigh(key)
      }
      }}>
      <div className = "Feed-pet-info">{profData[key].name}, {profData[key].type}</div>
      <img className = "img-responsive Feed-pet-pic" src={profData[key].animalPhotoPath ? profData[key].animalPhotoPath : pet_default} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
      {(idToken && (idToken['https://PetAway.com/role'] === 'owner' || (idToken['https://PetAway.com/role'] === 'foster' && profData[key].status != 'home'))) && <>
        <div className={'Feed-btn Feed-stat-cell'+(profData[key].status==='travelling'?' red':'')}></div>
        <header className = "Feed-pet-status">Status: {profData[key].status==='travelling'?'pending':profData[key].status}</header>
      </>}
      {idToken && idToken['https://PetAway.com/role'] === 'foster' && profData[key].status === 'home' && <button className='Feed-btn' onClick = {(e) => {
                  // setHigh(null);
                  (async () => {
                    const role = idToken['https://PetAway.com/role']
                    const accessToken = await getAccessTokenSilently();
                    console.log(accessToken)
                    axiosInstance
                      .put(routes[role].acceptpet, {
                        "ownerEmail": profData[key].ownerEmail,
                        "animalName": profData[key].name,
                        "animalType": profData[key].type,
                        "animalAge": profData[key].age,
                      }, {
                        headers: {
                          Authorization: `Bearer ${accessToken}`,
                        },
                      })
                      .then(() => {});
                  })();
                  e.stopPropagation();
                  // setHigh(null)
                }}>
        <header className="ButtonText White-btn">Adopt</header>
      </button>}
    </div>)
  }
  return (<>
        <div className = "Feed">
            {objs}
        </div>
        {high != null && <div className = 'App-profile-div'>
        <img className = "img-responsive App-profile-pic-detail" src={profData[high].animalPhotoPath ? profData[high].animalPhotoPath : pet_default} onError = {(ev) => {ev.target.src=pet_default}}></img>
        <div className='App-profile-label App-email-label'>Name</div>
        <input className='App-profile-input App-email-form' value = {/*auxData.email*/profData[high].name} readOnly/>
        <div className='App-profile-label'>Type</div>
        <input className='App-profile-input' value = {profData[high].type} readOnly/>
        <div className='App-profile-label'>Age</div>
        <input type='text' className='App-profile-input' value = {profData[high].age} readOnly/>
        <div className='App-profile-label'>Description</div>
        <input type='text' className='App-profile-input App-profile-desc' value = {profData[high].description} readOnly/>
      </div>}
      </> 
  )
}

export default Feed
