<<<<<<< HEAD
import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import './BannerButton.css'
=======
import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
>>>>>>> backupidp

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0()

<<<<<<< HEAD
  return <button className = "BannerButton" onClick={() => loginWithRedirect()}>
    <header className="ButtonText">Sign in</header>
  </button>;
};
=======
  return <button onClick={() => loginWithRedirect()}>Log In</button>
}
>>>>>>> backupidp

export default LoginButton
