/* eslint-disable no-undef */

const base = process.env.API_HOSTNAME ? 
    `http://${process.env.API_HOSTNAME}:8001/api/`: 'http://localhost:5000/api/v1/';
const routes = {
    owner: {
        addowner: "Owners/registerOwner",
        getowner: "Owners/getOwner",
        updateowner: 'Owners/updateOwner',
    },
    foster: {
        addfoster: 'Fosters/registerFoster',
        getfoster: 'Fosters/getFoster',
        updatefoster: 'Fosters/updateFoster',
    },
    rescuer: {
        addrescuer: 'Rescuers/registerRescuer',
        getrescuer: 'Rescuers/getRescuer',
        updaterescuer: 'Rescuers/updateRescuer',
    },
};

export { base, routes };