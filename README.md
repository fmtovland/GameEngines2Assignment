# Overview

The approach taken to mixing and matching behaviours, or influencers as I in my infinite wisdom decided they should be called, is at best messy. Back when the intrim was submitted the assumption was multiple behaviours could be heaped upon the boid at the prefab level. However, when it came time to code the behaviours, it became apparant being able to access behaviours directly with other behaviours or better still being able to implement multiple behaviours within a behaviour seemed advantagous. As such both architectures are used interchangably, and there is no way to find whether they are assigned at the prefab level or if the boid was subclassed and default behaviours added. I appologise. 

# Camera

The camerawork could have been better. I had it offset pursuing various ships, but that did not leave you with a very good view of the action. So controller controlled camera. The entire simulation is completely autonamous for what it's worth besides the camera. However, I wasn't sure where the camera should be at all times, so I left it as user controllable. You may explore the scene at your leisure.

# Approach

The majority of the excercise consists of a ship throwing out a sphere cast to find a target, then chasing that target. It also throws out raycasts and if an enemy is spotted by the ray cast, a projectile is instatiated. These are also boids, with their own behaviours. The goauld get lasers, because thats what they had in the show. Lasers travel in a straight line. The tauri (humans) have homing missiles, again like the show. And if that sounds like the writers denied the badguys a pretty obvious technological advantage, it's because in the context of the show the goauld stole everything they know from the ancients, and so might have some gaps in their knowledge of ancient technology. The drones that spawn at the end of the sequence were intended to seek out ships the same way as fighters seek out their targets, with a spherecast. But for some reason they would not lock on to the ha'taks, so they just fly to a predetermined location. 

Fighters have hitpoints, and when they run out they explode. Explosions damage ships that are caught by them.

# Story

This is a recreation of the battle of antartica seen here 

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/XKvLHLqPUQc/0.jpg)](https://www.youtube.com/watch?v=XKvLHLqPUQc)

The prometheus and jets arrive to protect sg1's tel'tak from the gaould. After SG1 completes their mission the teltak flies off and the drones rise from the earth to destroy the gaould fleet

# Visuals

The explosions are orange spheres that expand in size then self delete. The missiles and lasers are boids like the ships. A list of where my models came from may be found in Assets/Licences.md. They all either came from either sketchfab or turbosquid. The snow is the jet's camo texture. 
