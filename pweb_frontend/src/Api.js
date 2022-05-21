const base = "http://localhost:5000/";
const routes = {
    owner: {
        addowner: "/api/v1/Owners/registerOwner",
        getowner: "/api/v1/Owners/getOwner",
    },
    foster: {
        addfoster: 'api/v1/Fosters/registerFoster',
        getfoster: '',
    },
    rescuer: {
        addrescuer: '',
        getrescuer: '',
    },
};

export { base, routes };