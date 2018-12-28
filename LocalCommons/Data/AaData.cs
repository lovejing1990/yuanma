// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using LocalCommons.Data.Database;

namespace LocalCommons.Data
{
	/// <summary>
	/// Wrapper for all file databases.
	/// </summary>
	public class AaData
	{
		public MapDb MapDb = new MapDb();
		public MonsterDb MonsterDb = new MonsterDb();
		public DoodadDb DoodadDb = new DoodadDb();
		
		public AbilityDb AbilityDb = new AbilityDb();
		public AbilityTreeDb AbilityTreeDb = new AbilityTreeDb();
		public BarrackDb BarrackDb = new BarrackDb();
		public ChatMacroDb ChatMacroDb = new ChatMacroDb();
		public CustomCommandDb CustomCommandDb = new CustomCommandDb();
		public DialogDb DialogDb = new DialogDb();
		public ExpDb ExpDb = new ExpDb();
		public ItemDb ItemDb = new ItemDb();
		public JobDb JobDb = new JobDb();
		public ServerDb ServerDb = new ServerDb();
		public ShopDb ShopDb = new ShopDb();
		public SkillDb SkillDb = new SkillDb();
		public SkillTreeDb SkillTreeDb = new SkillTreeDb();
		public StanceConditionDb StanceConditionDb = new StanceConditionDb();
		public HelpDb HelpDb = new HelpDb();
	}
}
