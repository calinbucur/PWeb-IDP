import { Box, Button, Dialog, DialogContent, DialogContentText, DialogTitle, Modal, TextField, Typography } from "@mui/material";
import { useState } from "react";
import { Animal } from "../App";
import './AddAnimalModal.css';

export interface AddAnimalModalProps {
    isOpen: boolean;
    handleClose: () => void;
    addAnimal: (animal: Animal) => void;
}

export function AddAnimalModal({isOpen, handleClose, addAnimal}: AddAnimalModalProps) {
  const [animalName, setAnimalName] = useState("");
  const [animalDescription, setAnimalDescription] = useState("");

  return (<Dialog
        open={isOpen}
        onClose={handleClose}
      >
        <DialogTitle>Add new animal</DialogTitle>
        <DialogContent>
          <TextField
            value={animalName}
            margin="dense"
            label="Name"
            fullWidth
            variant="standard"
            onChange={(event) => setAnimalName(event.target.value)}
          />
          <TextField
            value={animalDescription}
            margin="dense"
            label="Description"
            fullWidth
            variant="standard"
            onChange={(event) => setAnimalDescription(event.target.value)}
          />
          <Button
            onClick={() => {
              const animal: Animal = {
                name: animalName,
                description: animalDescription
              } as Animal;

              addAnimal(animal);
              handleClose();
            }}
            >
            Add animal
          </Button>
        </DialogContent>
      </Dialog>);
}