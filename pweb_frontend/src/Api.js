/* eslint-disable no-undef */
const base = process.env.REACT_APP_API_HOSTNAME ? 
    `https://${process.env.REACT_APP_API_HOSTNAME}:8443/api/`: 'http://localhost:5000/api/v1/';
console.log("api url " + base)
const routes = {
    owner: {
        addowner: "/Owners/registerOwner",
        getowner: "/Owners/getOwner",
        updateowner: '/Owners/updateOwner',
        getanimals: '/Owners/viewOwnerAnimals',
        getPetId: 'Owners/getOwnerSpecificAnimalByDbId'
    },
    foster: {
        addfoster: '/Fosters/registerFoster',
        getfoster: '/Fosters/getFoster',
        updatefoster: '/Fosters/updateFoster',
        getanimals: '/Owners/viewRescuableAnimals',
        acceptpet: '/Fosters/proposeTransfer',
        getext: '/Fosters/getFosterExternal',
        gettaken: '/Fosters/viewFosterAnimals',
    },
    rescuer: {
        addrescuer: '/Rescuers/registerRescuer',
        getrescuer: '/Rescuers/getRescuer',
        updaterescuer: '/Rescuers/updateRescuer',
        getanimals: '/Transports/viewDisponibleTransports',
        takeTrans: '/Rescuers/takeTransport',
        getTrans: '/Rescuers/viewRescuerPendingTransports',
        endTrans: '/Rescuers/finishTransport',
    },
    animal: {
        add: "/Owners/addAnimal"
    }
};

export { base, routes };