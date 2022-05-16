import './App.css';
import LoginButton from './LoginButton'
import { Routes, Route, Link } from "react-router-dom";
import logo from './logo.png';

function Home() {
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
  );
}

function About() {
  return (
    <>
      <main>
        <h2>Who are we?</h2>
        <p>
          That feels like an existential question, don't you
          think?
        </p>
      </main>
      <nav>
        <Link to="/">Home</Link>
      </nav>
    </>
  );
}

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<>
          <header className="App-banner">
            <header className="App-title">
              PetAway
            </header>
            <LoginButton></LoginButton>
            {/* <img src={logo} alt="Logo" /> */}
          </header>
          <img className = "App-big-logo" src={logo} alt="Logo"/>
          <Home />
          </>} />
        <Route path="home" element={<><About /></>} />
        
      </Routes>
      {/* <header className="App-banner">
        <LoginButton></LoginButton>
      </header> */}
    </div>
  );
}

export default App;
