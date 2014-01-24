Worldsmith
==========

Open source Dota 2 Mod Editor inspired by Warcraft 3's World Edit.  

You can contact me on IRC at #dota2mods on irc.gamesurge.net.  


## Contributing

Like this project? Want to help?  Here are a few ideas:

* If you can, please [Donate] to keep the project running.  
* If you can program, I appreciate pull requests.  Please see the pull request guidelines below.
* If you can help translate Worldsmith, please get in contact with me or submit a pull request. 
* Tell the world about Worldsmith.  


## Credits

Without a few people, this project would be much much harder.  In no particular order:

* penguinwizzard for figuring out how to write maps.
* tet, Sir_Kane, and hex6 for finding the strings for most of the flags and enums.
* hex6 for doing the legwork for setting up translations.
* Quintinity for cleaning up the quality and doing incredibly helpful quality work.  
* OrangeSodaSmurf for providing a coupon for a free domain name.

### Translation credits

* Swedish - hex6



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
