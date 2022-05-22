/* eslint-disable no-undef */
const base = process.env.REACT_APP_API_HOSTNAME ? 
    `https://${process.env.REACT_APP_API_HOSTNAME}:8001/api/`: 'http://localhost:5000/api/v1/';
console.log("api url " + base)
const routes = {
    owner: {
        addowner: "/Owners/registerOwner",
        getowner: "/Owners/getOwner",
        updateowner: '/Owners/updateOwner',
        getanimals: '/Owners/viewOwnerAnimals',
    },
    foster: {
        addfoster: '/Fosters/registerFoster',
        getfoster: '/Fosters/getFoster',
        updatefoster: '/Fosters/updateFoster',
        getanimals: '/Owners/viewRescuableAnimals',
        acceptpet: '/Fosters/proposeTransfer',
        getext: '/Fosters/getFosterExternal',
    },
    rescuer: {
        addrescuer: '/Rescuers/registerRescuer',
        getrescuer: '/Rescuers/getRescuer',
        updaterescuer: '/Rescuers/updateRescuer',
    },
    animal: {
        add: "/Owners/addAnimal"
    }
};

export { base, routes };