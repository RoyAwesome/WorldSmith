WorldSmith
==========

Open source Dota 2 Mod Editor inspired by Warcraft 3's World Edit.  

You can contact me on IRC at #dota2mods on irc.gamesurge.net.  


## Contributing

Like the project? If you can, please [Donate] to keep the project running.  

If you can program, I appreciate pull requests.  Please see the pull request guidelines below.

Can't do either of the above?  Tell the world about Worldsmith.  


## Credits

Without a few people, this project would be much much harder.  In no particular order:

* penguinwizzard for figuring out how to write maps
* tet, Sir_Kane, and hex6 for finding the strings for most of the flags and enums
* Quintinity for some increidbly helpful commits



## Compiling the source

All major dependencies are included in the repository.  They are 
* [KVLib] - Valve Key-Value parsing library in C#
* [Sprache] - Monadic Parsing library for C# 

Worldsmith was created with Visual Studio 2013.

If you change any of the data schemas, be sure to run the ClassGen build target.  This will update the data class definitions.

## Pull Requests 
I greatly appreciate pull requests, but I ask contributers to follow some guidelines. 

* Worldsmith uses Microsoft's C# style guide.  
* Please follow the general style of the rest of the code base.
* Use spaces, not tabs.  
* Use Windows line endings.



[KVLib]: https://github.com/RoyAwesome/KVLib
[Sprache]: https://github.com/sprache/Sprache
[Donate]: https://www.paypal.com/us/cgi-bin/webscr?cmd=_flow&SESSION=DPJR9Acbb_yxXTU1OIHLymU4mgo36T5Bk3ylNjG0n96UnajyFRC7kkWGB6e&dispatch=5885d80a13c0db1f8e263663d3faee8def8934b92a630e40b7fef61ab7e9fe63
