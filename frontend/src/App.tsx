import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Button, Checkbox, Divider, List, ListItemText, TextField } from '@mui/material';
import { isEqual } from "lodash";
import { AddAnimalModal } from './AddAnimalModal/AddAnimalModal';
export interface Animal {
  id: string;
  name: string;
  type: string;
  isHome: boolean;
  description: string;
  isAggresive: boolean;
  isSick: boolean;
  isStray: boolean;
  age: number;
  location: string;
}

const API_URL = `http://${process.env.API_HOSTNAME ?? "localhost"}:5000/api`

function App() {
  const [animals, setAnimals] = useState<Animal[]>([]);
  const [isModalOpen, setIsModalOpen] = useState(false);

  async function getTodoItems() {
    try {
      const newAnimals = await axios.get(`${API_URL}/animals`);
      setAnimals(newAnimals.data)
    } catch {
      setAnimals([]);
      alert("Could not get animals from database");
    }
  }

  async function addAnimal(animal: Animal) {
    try {
      const response = await axios.post(`${API_URL}/animals`, animal);
      const newAnimal = response.data as Animal
      const newAnimals = [...animals, newAnimal]
      setAnimals(newAnimals)
    } catch {
      alert("Could not add animal");
    }
  }

  useEffect(() => {
    getTodoItems();
  }, [])

  return (
    <div className="App">
      <div>
        <h1>{animals.length} animals in need of help</h1>
        <List>
          {
            animals.map(animal => (
              <>
              <ListItemText
              primary={animal.name}
              secondary={animal.description}
              />
              <Divider variant="inset" component="li" />
              </>
              ))
          }
        </List>
        <Button
          onClick={() => setIsModalOpen(true)}
        >
          Add new animal
        </Button>
      </div>
      <AddAnimalModal
          isOpen={isModalOpen}
          handleClose={() => setIsModalOpen(false)}
          addAnimal={addAnimal}
        />
    </div>
  )
}

export default App;
