const base = "http://localhost:5000/";
const routes = {
    owner: {
        addowner: "/api/v1/Owners/registerOwner",
        getowner: "/api/v1/Owners/getOwner",
        updateowner: '/api/v1/Owners/updateOwner',
    },
    foster: {
        addfoster: 'api/v1/Fosters/registerFoster',
        getfoster: 'api/v1/Fosters/getFoster',
        updatefoster: 'api/v1/Fosters/updateFoster',
    },
    rescuer: {
        addrescuer: 'api/v1/Rescuers/registerRescuer',
        getrescuer: 'api/v1/Rescuers/getRescuer',
        updaterescuer: 'api/v1/Rescuers/updateRescuer',
    },
};

export { base, routes };