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
import pfp_default from './pfp_default.jpg'

const Feed = (props) => {
  const { idToken, setIdToken } = props;
  const { logout, user, getAccessTokenSilently, getIdTokenClaims } = useAuth0()
  const [profData, setProfData] = useState({})
  const {addPet, setAddPet} = props
  const {high, setHigh} = props
  const {high2, setHigh2} = props
  const {profile, setProfile} = props
  const [fosters, setFosters] = useState({})
  const [anims, setAnims] = useState({})
  const [pendTrans, setPendTrans] = useState({})
  const [taken, setTaken] = useState({})

  const axiosInstance = axios.create({
    baseURL: base,
    // timeout: 1000,
  });

  const get = () => {
    (async () => {
      const role = idToken?idToken['https://PetAway.com/role']:''
      const accessToken = await getAccessTokenSilently();
      //console.log(accessToken)
      if (role) axiosInstance
        .get(routes[role].getanimals, {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(({data}) => {
          // console.log(data)
          //console.log('hau')
          setProfData(data)
        })
    })();
  }
  

  const get_fext = (mail, key) => {
    (async () => {
      // const role = idToken?idToken['https://PetAway.com/role']:''
      // let p = {}
      // p[role + 'Email'] = mail
      const accessToken = await getAccessTokenSilently();
      //console.log(accessToken)
      axiosInstance
        .get(routes.foster.getext, {
          params: {fosterEmail:mail},
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(({data}) => {
          // console.log(data)
          const x = fosters
          x[key] = data
          setFosters(x)
          // fosters[key] = data;
          //console.log('hau')
          // setProfData(data)
        })
    })();
  }
  const get_aext = (mail, aid, key) => {
    (async () => {
      // const role = idToken?idToken['https://PetAway.com/role']:''
      // let p = {}
      // p[role + 'Email'] = mail
      const accessToken = await getAccessTokenSilently();
      //console.log(accessToken)
      axiosInstance
        .get(routes.owner.getPetId, {
          params: {
            ownerEmail:mail,
            animalId: aid,
          },
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(({data}) => {
          // console.log(data)
          const x = anims
          x[key] = data
          setAnims(x)
          // fosters[key] = data;
          //console.log('hau')
          // setProfData(data)
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
  const rol = idToken?idToken['https://PetAway.com/role']:''
  const get_trans = () => {
    (async () => {
      const role = idToken?idToken['https://PetAway.com/role']:''
      const accessToken = await getAccessTokenSilently();
      //console.log(accessToken)
      axiosInstance
        .get(routes[role].getTrans, {
          headers: {
            Authorization: `Bearer ${accessToken}`,
          },
        })
        .then(({data}) => {
          // console.log(data)
          //console.log('hau')
          setPendTrans(data)
        })
    })();
  }
  if(rol === 'rescuer') {
    get_trans()
    if(pendTrans.length > 0) {
      // console.log("bad")
      // console.log(pendTrans)
      get_fext(pendTrans[0].fosterEmail, -1)
      // console.log(fosters)
      get_aext(pendTrans[0].ownerEmail, pendTrans[0].animalId, -1)
      // console.log(anims)
      objs.push(<div className = {high === -1?"Feed-item Feed-highlight":"Feed-item"} key = {-1} onClick={()=>{
        setAddPet(false)
        setProfile(false)
        if (high === -1) {
          setHigh(null)
        }
        else {
          setHigh(-1)
        }
        }}>
          <div className = "Feed-pet-info">{anims[-1]?anims[-1][0].name:''}, {anims[-1]?anims[-1][0].type:''}</div>
          <img className = "img-responsive Feed-pet-pic" src={anims[-1]?(anims[-1][0].animalPhotoPath ? anims[-1][0].animalPhotoPath : pet_default):''} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
          <div className = "Feed-pet-info foster-opt">{fosters[-1]?(fosters[-1].name?fosters[-1].name:fosters[-1].email):''}</div>
          <img className = "img-responsive Feed-pet-pic foster-opt-pic" src={fosters[-1]?(fosters[-1].photoPath ? fosters[-1].photoPath : pfp_default):pfp_default} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
          {!pendTrans[0].isFinished && <button className='Feed-btn' onClick = {(e) => {
                    // setHigh(null);
                    (async () => {
                      const role = idToken?idToken['https://PetAway.com/role']:''
                      const accessToken = await getAccessTokenSilently();
                      // console.log(accessToken)
                      if (role) axiosInstance
                        .put(routes[role].endTrans, {},{
                          headers: {
                            Authorization: `Bearer ${accessToken}`,
                          },
                        })
                        .then(() => {});
                    })();
                    e.stopPropagation();
                    // setHigh(null)
                  }}>
            <header className="ButtonText White-btn">Finish</header>
          </button>}
        </div>)
    }
  }
  const fobjs = []
  if(rol === 'foster') {
    const get_taken = () => {
      (async () => {
        const role = idToken?idToken['https://PetAway.com/role']:''
        const accessToken = await getAccessTokenSilently();
        //console.log(accessToken)
        if (role) axiosInstance
          .get(routes.foster.gettaken, {
            headers: {
              Authorization: `Bearer ${accessToken}`,
            },
          })
          .then(({data}) => {
            // console.log(data)
            //console.log('hau')
            setTaken(data)
          })
      })();
    }
    get_taken()
    for (const key in taken) {
      fobjs.push(<div className = {high2 === key?"Feed-item Feed-highlight":"Feed-item"} key = {key} onClick={()=>{
        setAddPet(false)
        setProfile(false)
        if (high2 === key) {
          setHigh2(null)
          setHigh(null)
        }
        else {
          setHigh2(key)
          setHigh(null)
        }
        }}>
        <div className = "Feed-pet-info">{taken[key].name}, {taken[key].type}</div>
        <img className = "img-responsive Feed-pet-pic" src={taken[key].animalPhotoPath ? taken[key].animalPhotoPath : pet_default} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
        {(idToken && (idToken['https://PetAway.com/role'] === 'owner' || (idToken['https://PetAway.com/role'] === 'foster' && taken[key].status != 'home'))) && <>
          <div className={'Feed-btn Feed-stat-cell'+(taken[key].status==='travelling'?' red':'')}></div>
          <header className = "Feed-pet-status">Status: {taken[key].status==='travelling'?'pending':taken[key].status}</header>
        </>}
        </div>)
    }
  }
  for (const key in profData) {
    // console.log(profData[0])
    
    // console.log(fosters)
    // console.log(key)
    // console.log(fosters[key]?fosters[key].name:'')
    if (idToken && idToken['https://PetAway.com/role'] != 'rescuer') {
      objs.push(<div className = {high === key?"Feed-item Feed-highlight":"Feed-item"} key = {key} onClick={()=>{
        setAddPet(false)
        setProfile(false)
        if (high === key) {
          setHigh(null)
          setHigh2(null)
        }
        else {
          setHigh(key)
          setHigh2(null)
        }
        }}>
        <div className = "Feed-pet-info">{profData[key].name}, {profData[key].type}</div>
        <img className = "img-responsive Feed-pet-pic" src={profData[key].animalPhotoPath ? profData[key].animalPhotoPath : pet_default} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
        {(idToken && (idToken['https://PetAway.com/role'] === 'owner' || (idToken['https://PetAway.com/role'] === 'foster' && profData[key].status != 'home'))) && <>
          <div className={'Feed-btn Feed-stat-cell'+(profData[key].status==='travelling'?' red':'')}></div>
          <header className = "Feed-pet-status">Status: {profData[key].status==='travelling'?'pending':profData[key].status}</header>
        </>}
        {idToken && idToken['https://PetAway.com/role'] === 'owner' && profData[key].status != 'home' && <>
          {get_fext(profData[key].crtFosterEmail, key)}
          <div className = "Feed-pet-info foster-opt">{fosters[key]?(fosters[key].name?fosters[key].name:fosters[key].email):''}</div>
          <img className = "img-responsive Feed-pet-pic foster-opt-pic" src={fosters[key]?(fosters[key].photoPath ? profData[key].photoPath : pfp_default):pfp_default} /*onError = {(ev) => {ev.target.src=pet_default}}*/></img>
        </>}
        {idToken && idToken['https://PetAway.com/role'] === 'foster' && profData[key].status === 'home' && <button className='Feed-btn' onClick = {(e) => {
                    // setHigh(null);
                    (async () => {
                      const role = idToken['https://PetAway.com/role']
                      const accessToken = await getAccessTokenSilently();
                      // console.log(accessToken)
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
    } else if (idToken && idToken['https://PetAway.com/role'] === 'rescuer') {
      get_fext(profData[key].fosterEmail, key)
      get_aext(profData[key].ownerEmail, profData[key].animalId, key)
      // console.log(key)
      // console.log(profData)
      // console.log(fosters)
      // console.log(anims)
      objs.push(<div className = {high === key?"Feed-item Feed-highlight":"Feed-item"} key = {key} onClick={()=>{
        setAddPet(false)
        setProfile(false)
        if (high === key) {
          setHigh(null)
          setHigh2(null)
        }
        else {
          setHigh(key)
          setHigh2(null)
        }
        }}>
          <div className = "Feed-pet-info">{anims[key]?anims[key][0].name:''}, {anims[key]?anims[key][0].type:''}</div>
          <img className = "img-responsive Feed-pet-pic" src={anims[key]?(anims[key][0].animalPhotoPath ? anims[key][0].animalPhotoPath : pet_default):''} ></img>
          <div className = "Feed-pet-info foster-opt">{fosters[key]?(fosters[key].name?fosters[key].name:fosters[key].email):''}</div>
          <img className = "img-responsive Feed-pet-pic foster-opt-pic" src={fosters[key]?(fosters[key].photoPath ? fosters[key].photoPath : pfp_default):pfp_default} ></img>
          <button className='Feed-btn' onClick = {(e) => {
                    // setHigh(null);
                    (async () => {
                      const role = idToken['https://PetAway.com/role']
                      const accessToken = await getAccessTokenSilently();
                      // console.log(accessToken)
                      axiosInstance
                        .put(routes[role].takeTrans, {
                          "transportId": profData[key].transportId,
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
            <header className="ButtonText White-btn">Rescue</header>
          </button>
        </div>)
    }
  }
  return (<>
        <div className = "Feed">
            {objs.concat(fobjs)}
        </div>
        {high != null && <div className = 'App-profile-div'>
        {idToken && idToken['https://PetAway.com/role'] != 'rescuer' && <div className='sideContainer'>
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
        {idToken && idToken['https://PetAway.com/role'] === 'rescuer' && <div className='sideContainer'>
        <img className = "img-responsive App-profile-pic-detail" src={anims[high][0].animalPhotoPath ? anims[high][0].animalPhotoPath : pet_default} onError = {(ev) => {ev.target.src=pet_default}}></img>
        <div className='App-profile-label App-email-label'>Name</div>
        <input className='App-profile-input App-email-form' value = {/*auxData.email*/anims[high][0].name} readOnly/>
        <div className='App-profile-label'>Type</div>
        <input className='App-profile-input' value = {anims[high][0].type} readOnly/>
        <div className='App-profile-label'>Age</div>
        <input type='text' className='App-profile-input' value = {anims[high][0].age} readOnly/>
        <div className='App-profile-label'>Description</div>
        <input type='text' className='App-profile-input App-profile-desc' value = {anims[high][0].description} readOnly/>
        </div>}
        {fosters[high] && <div className = 'sideContainer'>
        <img className = "img-responsive App-profile-pic-detail" src={fosters[high].photoPath ? fosters[high].photoPath : pfp_default} onError = {(ev) => {ev.target.src=pfp_default}}></img>
        <div className='App-profile-label App-email-label'>Email</div>
        <input className='App-profile-input App-email-form' value = {/*auxData.email*/fosters[high].email} readOnly/>
        <div className='App-profile-label'>Name</div>
        <input className='App-profile-input' value = {fosters[high].name} readOnly/>
        <div className='App-profile-label'>Phone Number</div>
        <input type='text' className='App-profile-input' value = {fosters[high].phoneNumber} readOnly/>
        <div className='App-profile-label'>Address</div>
        <input type='text' className='App-profile-input' value = {fosters[high].address} readOnly/>
        <div className='App-profile-label'>Capacity</div>
        <input type='text' className='App-profile-input' value = {fosters[high].crtCapacity + '/' + fosters[high].maxCapacity} readOnly/>
        </div>}
      </div>}
      {high2 != null && <div className = 'App-profile-div'>
        {idToken && idToken['https://PetAway.com/role'] != 'rescuer' && <div className='sideContainer'>
        <img className = "img-responsive App-profile-pic-detail" src={taken[high2].animalPhotoPath ? taken[high2].animalPhotoPath : pet_default} onError = {(ev) => {ev.target.src=pet_default}}></img>
        <div className='App-profile-label App-email-label'>Name</div>
        <input className='App-profile-input App-email-form' value = {/*auxData.email*/taken[high2].name} readOnly/>
        <div className='App-profile-label'>Type</div>
        <input className='App-profile-input' value = {taken[high2].type} readOnly/>
        <div className='App-profile-label'>Age</div>
        <input type='text' className='App-profile-input' value = {taken[high2].age} readOnly/>
        <div className='App-profile-label'>Description</div>
        <input type='text' className='App-profile-input App-profile-desc' value = {taken[high2].description} readOnly/>
        </div>}
        </div>}
      </> 
  )
}

export default Feed
