/*****************************  NOTICE  ********************************************
* This file was autogenerated.  Do not edit.                                       *
* Instead, modify the schema in DataSchema related to this class and regenerate it *
***********************************************************************************/
using System;
using System.ComponentModel;
using WorldSmith.Panels;
using WorldSmith.Dialogs;

namespace WorldSmith.DataClasses
{
	[DotaAction]
	[EditorGrammar("Spawn %UnitCount %UnitName around %Target with a radius of %Radius units for %Duration seconds.  After spawn, execute %OnSpawn actions")]
	public partial class SpawnUnit : TargetedAction
	{
		[Category("Misc")]
		[Description("Name")]
		[DefaultValue("")]
		public string UnitName
		{
			get;
			set;
		}

		[Category("Misc")]
		[Description("int")]
		[DefaultValue("")]
		public string UnitCount
		{
			get;
			set;
		}

		[Category("Misc")]
		[Description("int")]
		[DefaultValue("")]
		public string SpawnRadius
		{
			get;
			set;
		}

		[Category("Misc")]
		[Description("int")]
		[DefaultValue("")]
		public string Duration
		{
			get;
			set;
		}

		[Category("Misc")]
		[Description("Name")]
		[DefaultValue(null)]
		public ActionCollection OnSpawn
		{
			get;
			set;
		}

	}
}