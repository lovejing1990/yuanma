using ArcheAgeGame.ArcheAge.Network.Connections;

namespace ArcheAgeGame.ArcheAge.Structuring
{
	/// <summary>
	/// Stucture That Contains Information About Account
	/// </summary>
	public class Account
	{
		public uint AccountId { get; set; }
		public byte CharactersCount { get; set; }
		public int Session { get; set; } //cookie
		public bool IsWaitingForReAuthorization { get; set; }
		public ClientConnection Connection { get; set; } //текущее соединение
		public Character Character { get; set; } //имеющиеся на аккаунте персонажи
		public string Name { get; set; }
		public string Token { get; set; }
		public byte AccessLevel { get; set; }
		public byte Membership { get; set; }
		public string LastIp { get; set; }
		public long LastEnteredTime { get; set; }
	}
}
