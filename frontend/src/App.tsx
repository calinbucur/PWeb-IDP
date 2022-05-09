import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Button, Checkbox, TextField } from '@mui/material';
import { isEqual } from "lodash";
interface TodoItem {
  id: number;
  name: string;
  isComplete: boolean;
}

const API_URL = `http://${process.env.API_HOSTNAME ?? "localhost"}:5000/api`

function App() {
  const [todoItems, setTodoItems] = useState<TodoItem[]>([]);
  const [modifiedTodoItems, setModifiedTodoItems] = useState<TodoItem[]>([]);

  const areItemsModified = isEqual(todoItems, modifiedTodoItems);

  async function getTodoItems() {
    try {
      const newTodoItems = await axios.get(`${API_URL}/todoitems`);
      setTodoItems(newTodoItems.data)
    } catch {
      setTodoItems([]);
    }
  }

  useEffect(() => {
    getTodoItems();
  }, [])

  useEffect(() => {
    setModifiedTodoItems(todoItems);
  }, [todoItems])

  return (
    <div className="App">
      <div>
        <h1>Todo List</h1>
        {
          modifiedTodoItems.map(todoItem => (<div>
            <TextField
                id="outlined-basic"
                label="Outlined"
                variant="outlined"
                value={todoItem.name}
                onChange={event => {
                  const name = event.target.value;
                  setModifiedTodoItems(
                    modifiedTodoItems.map((item) => item.id === todoItem.id ? {...item, name} : item)
                  )
                }}
            />
            <Checkbox
              value={todoItem.isComplete}
              onChange={event => {
                const isComplete = event.target.checked;
                setModifiedTodoItems(
                  modifiedTodoItems.map((item) => item.id === todoItem.id ? {...item, isComplete} : item)
                )
              }}/>
          </div>))
        }
        <Button
          variant="contained"
          disabled={!areItemsModified}
        >
          Save changes
        </Button>
      </div>
    </div>
  )
}

export default App;
