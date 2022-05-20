import React from "react";
import "./Feed.css"

const Feed = () => {
    let objs = []
    for (let i = 0; i < 20; i++) {
        if (i === 4) {
            objs.push(<div className = "Feed-item Feed-highlight" key = {i}></div>)
        } else
        objs.push(<div className = "Feed-item" key = {i}></div>)
    }
    return (
        <div className = "Feed">
            {objs}
        </div>
    );
};

export default Feed;