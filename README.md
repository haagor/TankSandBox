# TankSandBox

## Initials motivations

![](https://github.com/haagor/TankSandBox/blob/master/img/comboIMG1.PNG)

This is my second Unity project. It's an occasion to start from scratch and alone for understand truly the basic of this framework. 

I want to make a small game with a tank. My main interest isn't to concentrate on the fight but on the travel. I want to gather a crew and one tank to face a harsh biome like desert. Move forward with the tank should be satisfying and to do that, I will jump on some physic simulation challenge.

I find inspiration in Dune, Mad Max, Star Citizen, World of Tank, Hell let loose, Fury movie...

![](https://github.com/haagor/TankSandBox/blob/master/img/comboIMG2.PNG)

Hell let loose is my first experience with tank multiplayer. The crew is  composed by one chief, one pilot, one shooter. Their different view angle and mission in the tank provide a great teammate experience.

![](https://github.com/haagor/TankSandBox/blob/master/img/comboPiloteView.PNG)

![](https://github.com/haagor/TankSandBox/blob/master/img/comboShooterView.PNG)

## The adventure begin

![](https://github.com/haagor/TankSandBox/blob/master/img/CaptureMoveCollider1.PNG)

I started with a simple terrain look like cubic desert and a nice small tank. I putted some colliders, write a script to move the tank, add engine sound...

It's seemed clear at this step that I have to focus on specifics things for learn and stop to rush a nice result. So I deep dive in WheelCollider and mobility aspect, sound aspect, FX 2D, shell shot and collider, turret features and control command. I started to explain chronologically my work but at a moment it seemed more pertinent to split my work in chapter.

### Mobility

---

It was a cool start, but I wanted a better tank simulation. I discovered then the WheelCollider. Next I explored the different strategies to simulate tank tracks.

![](https://github.com/haagor/TankSandBox/blob/master/img/CaptureWheelCollider2.PNG)

Next I followed this tutorial [https://habr.com/en/post/116088/] to deep dive to one simulate tank tracks strategy.

![](https://github.com/haagor/TankSandBox/blob/master/img/CaptureTrack1.PNG)

Once this tutorial done, I found my tracks satisfying. There is others methods to simulate tracks but this was ok for now. Later I probably update tracks with some capsule collider like in this example [https://www.youtube.com/watch?v=HSdKs4ZGDKo]

![](https://github.com/haagor/TankSandBox/blob/master/img/capsuleCollider1.PNG)

Next I make another tank with just multiple wheel :

![](https://github.com/haagor/TankSandBox/blob/master/img/wheelTrack2.PNG)

Then I created a scene to experiment the combo gear and track :

![](https://github.com/haagor/TankSandBox/blob/master/img/gearFabric1.PNG)

### Turret

---

Time to work on the rest of the tank : the turret. I maked it with some simple geometric. I colored the rotate points with red. I written some scripts to use mouse input to rotate turret and camera but also the canon. With all of that I obtained something seem like a tank.

![](https://github.com/haagor/TankSandBox/blob/master/img/turret1.PNG)

### Shell shot and physics

---

I drawn simple shell and written a script to shoot it on mouse click. I shot everywhere and I filled out my map with shells, really funny. I added inverse force on shot. I wanted also a reload timer and that trigger the creation of HUD.

### HUD

---

I discovered sprites and make my first slider to visualise my reload. I also wanted to power on my tank  so I added a indicator for that.

![](https://github.com/haagor/TankSandBox/blob/master/img/hud1.PNG)

### Sound

---

I added rapidly a shot sound. With the inverse force on shot, that created a good sensation on shot. I also triggered a sound for the engine and wheel movement.

![](https://github.com/haagor/TankSandBox/blob/master/img/tank1.PNG)

### Light

---

I wanted to discover a little bit what is possible with light. I added headlights and try the "spot light". More important, I wanted a trail effect on the shell.

![](https://github.com/haagor/TankSandBox/blob/master/img/shellTrail1.PNG)

With the "trail renderer" component and the light apply on shader it is really easy to have a first version of this effect. But like other part I wanted deepen later.

![](https://github.com/haagor/TankSandBox/blob/master/img/fusionShell1.PNG)

### Terrain

---

![](https://github.com/haagor/TankSandBox/blob/master/img/redSand1.PNG)
![](https://github.com/haagor/TankSandBox/blob/master/img/redSand2.PNG)

- HDRP
- Light
- Fog
- Sky

I followed this tutorial [https://www.youtube.com/watch?v=Y7r5n5TsX_E] to discover shader and try to obtain pretty cloud, and hope to make some sand storm. Here my first try with shader :

![](https://github.com/haagor/TankSandBox/blob/master/img/Cloud1.PNG)

---

Simon P

