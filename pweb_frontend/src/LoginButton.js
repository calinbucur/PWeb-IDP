import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
import './BannerButton.css'

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0()

  return <button className = "BannerButton" onClick={() => loginWithRedirect()}>
    <header className="ButtonText">Sign in</header>
  </button>
}

export default LoginButton
