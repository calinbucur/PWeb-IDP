const base = `http://kong:8001/api/`
// const base = "http://localhost:5000/api/v1/";
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