# Space Hero

Simple Guitar Hero inspired Unity 2D learning game.

# Unity version

2018.3.14f1

# Getting started

1. Clone the repo with `git clone git@github.com:mickeyren/spacehero.git`.
2. Open Unity Hub and add the `spacehero` folder.
3. You should now be able to click on the project and play it in Unity.

# Web build
There is also a Unity web build in `spacehero` folder. You can use [`http-server`](https://www.npmjs.com/package/http-server) to quickly launch an http server inside the directory and play the game in your browser:

1. `cd spacehero`
2. `npm install http-server -g`
3. `http-server`

# Packages
- [Unity 2D Destruction](https://github.com/mjholtzem/Unity-2D-Destruction) - responsible in generating the 2D polygon mesh for breaking apart the meteor after laser impact.
- [Texture Packer Importer](https://assetstore.unity.com/packages/tools/sprite-management/texturepacker-importer-16641) - Texture Packer was used to build the image atlas used in the game, and Texture Packer Importer is used to import them seamlessly into Unity.
- [DotTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676) - tweens the movement and scaling of the meteors going into the 
targets
- [Free Parallax for Unity (2D)](https://assetstore.unity.com/packages/tools/particles-effects/free-parallax-for-unity-2d-29422) - handy script to do multiple parallax layers
- [Dynamic Space Background Lite](https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606) - for the Nebula background
- [Graphy](https://assetstore.unity.com/packages/tools/gui/graphy-ultimate-fps-counter-stats-monitor-debugger-105778) - shows FPS in-game.

# Assets
- Sounds from [opengameart.org](https://opengameart.org)
- Pixel art from [craftpix.net](https://craftpix.net/product/pixel-art-space-trap-game-asset-pack/)

