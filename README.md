# Los Santos Life
[![No Maintenance Intended](http://unmaintained.tech/badge.svg)](http://unmaintained.tech/)

A gamemode where users play as a character in the world, among other players simultaneously in a multiplayer environment.
Harnessing the power of GTA Network, Los Santos Life is able to bring a roleplay experience to it's users.

# Setup process
Setting up the server should be relatively straight forward.
You will need a MySQL database accessible to the server in order to use the gamemode.
Setting up the configuration for the database credentials should be done in the `server.cfg` file.
The config keys `host`, `database`, `user` and `password` are self explanatory and must be set to your relevant database credentials.

# Development environment
The visual studio solution file is set up to copy the build to your server's resource folder at the path given with the user environment variable `LIFE_OUT_DIR` (since this prevents multiple people modifying the .sln file to their liking since the paths will vary.)
References should not be committed to the repository, and instead the path variable `LIFE_SERVER_ROOT_DIR` should be used to specify where the GTA Network files are.
