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

I star with a simple terrain look like cubic desert and a nice small tank. I put some colliders, write a script to move the tank, add engine sound...

It's seem clear at this step that I have to focus on specifics things for learn and stop to rush a nice result. So I deep dive in WheelCollider and mobility aspect, sound aspect, FX 2D, shell shot and collider, turret features and control command. I started to explain chronologically my work but at a moment it seemed more pertinent to split my work in chapter.

### Mobility

---

It was a cool start, but I want a better tank simulation. I discover then the WheelCollider. Next I explore the different strategies to simulate tank tracks.

![](https://github.com/haagor/TankSandBox/blob/master/img/CaptureWheelCollider2.PNG)

Next I follow this tutorial [https://habr.com/en/post/116088/] to deep dive to one simulate tank tracks strategy.

![](https://github.com/haagor/TankSandBox/blob/master/img/CaptureTrack1.PNG)

Once this tutorial done, I find my tracks satisfying. There is others methods to simulate tracks but this is ok for now. Later I probably update tracks with some capsule collider like in this example [https://www.youtube.com/watch?v=HSdKs4ZGDKo]

![](https://github.com/haagor/TankSandBox/blob/master/img/capsuleCollider1.PNG)

### Turret

---

Time to work on the rest of the tank : the turret. I make it with some simple geometric. I color the rotate points with red. Write some scripts to use mouse input to rotate turret and camera but also the canon. With all of that I obtain something seem like a tank.

![](https://github.com/haagor/TankSandBox/blob/master/img/turret1.PNG)

### Shell shot and physics

---

I drawn simple shell and write a script to shoot it on mouse click. I shot everywhere and I filled out my map with shells, really funny. I add inverse force on shot. I want also a reload timer and that trigger the creation of HUD.

### HUD

---

I discovered sprites and make my first slider to visualise my reload. I also want to power on my tank  so I add a indicator for that.

![](https://github.com/haagor/TankSandBox/blob/master/img/hud1.PNG)

### Sound

---

I add rapidly a shot sound. With the inverse force on shot, that created a good sensation on shot. I also trigger a sound for the engine and wheel movement.

![](https://github.com/haagor/TankSandBox/blob/master/img/tank1.PNG)

### Light

---

I want to discover a little bit what is possible with light. I add headlights and try the "spot light". More important, I want a trail effect on the shell.

![](https://github.com/haagor/TankSandBox/blob/master/img/shellTrail1.PNG)

With the "trail renderer" component and the light apply on shader it is really easy to have a first version of this effect. But like other part I want deepen later.

![](https://github.com/haagor/TankSandBox/blob/master/img/fusionShell1.PNG)



---

Simon P

