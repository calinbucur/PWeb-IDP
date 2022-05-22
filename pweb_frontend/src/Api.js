const base = "http://localhost:5000/";
const routes = {
    owner: {
        addowner: "/api/v1/Owners/registerOwner",
        getowner: "/api/v1/Owners/getOwner",
        updateowner: '/api/v1/Owners/updateOwner',
        getanimals: '/api/v1/Owners/viewOwnerAnimals',
    },
    foster: {
        addfoster: 'api/v1/Fosters/registerFoster',
        getfoster: 'api/v1/Fosters/getFoster',
        updatefoster: 'api/v1/Fosters/updateFoster',
        getanimals: '/api/v1/Owners/viewRescuableAnimals',
        acceptpet: '/api/v1/Fosters/proposeTransfer'
    },
    rescuer: {
        addrescuer: 'api/v1/Rescuers/registerRescuer',
        getrescuer: 'api/v1/Rescuers/getRescuer',
        updaterescuer: 'api/v1/Rescuers/updateRescuer',
    },
    animal: {
        add: "/api/v1/Owners/addAnimal"
    }
};

export { base, routes };