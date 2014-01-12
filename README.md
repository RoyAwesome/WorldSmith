Worldsmith
==========

Open source Dota 2 Mod Editor inspired by Warcraft 3's World Edit.  

You can contact me on IRC at #dota2mods on irc.gamesurge.net.  


## Contributing

Like this project? If you can, please [Donate] to keep the project running.  

If you can program, I appreciate pull requests.  Please see the pull request guidelines below.

Can't do either of the above?  Tell the world about Worldsmith.  


## Credits

Without a few people, this project would be much much harder.  In no particular order:

* penguinwizzard for figuring out how to write maps
* tet, Sir_Kane, and hex6 for finding the strings for most of the flags and enums
* Quintinity for some incredibly helpful commits



## Compiling the Source

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
[Donate]: https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=WF8XJ8SVQ9UAU&lc=US&item_name=Garrett%20Fleenor&item_number=Worldsmith&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted
