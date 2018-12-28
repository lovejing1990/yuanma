using ArcheAgeGame.ArcheAge.World;
using LocalCommons.Network;
using LocalCommons.Utilities;

namespace ArcheAgeGame.ArcheAge.Network.Packets.Server
{
    public class DoodadRemovedPacket : NetPacket
    {
        public DoodadRemovedPacket(Doodad doodad) : base(01, 0x107)
        {
	       /*
			 - <packet id="0x010701" name="SCDoodadRemovedPacket">
			   <part name="unk" type="c" /> 
			   <part name="unk" type="c" /> 
			   <part name="bc" type="d3" /> 
			   <part name="unk" type="c" /> 
			   </packet>
			 */

	        ns.Write((byte)0); //unk C
	        ns.Write((byte)0); //unk C
	        ns.Write((Uint24)doodad.LiveObjectId); //bc d3
	        ns.Write((byte)0); //unk C
        }
    }
}
