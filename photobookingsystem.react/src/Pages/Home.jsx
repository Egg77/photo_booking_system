import React from 'react';

function Home(){
    return (
        <>
        <h1>Home</h1>
        <h2>Test test test</h2>
        </>
    );
}

export default Home;

// How is this running? Not IIS obviiiii
// How is the watch working if I'm not actually running the watch?
// Why the bundle? Are there ways to split files up? 

/*
=> Long story short, this is all handled by create-react-app. When you run 'npm start', it runs a development server that:

- Creates a watch that quickly recompiles and refreshses the preview site every time you save
- Runs es-lint
- Packages everything up using webpack
- Runs using node
*/


// What about caching? Method uses platform.min as one react file to download
// When I make a change, how does it not cache the results?
 