// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using System;
using System.Collections.Generic;
using LocalCommons.Logging;
using LocalCommons.Utilities;

namespace LocalCommons.Network
{
/*

	/// <summary>
	/// Delegate Which Class When Packet Received
	/// </summary>
	/// <typeparam name="T">Any Connection Where T : IConnection, new()</typeparam>
	/// <param name="net">Connection </param>
	/// <param name="reader"></param>
	public delegate void OnPacketReceive<T>(T net, PacketReader reader);

	/// <summary>
	/// PacketHandler That Uses For Holding Delegate(OnPacketReceive) For Handle Packets.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PacketHandler<T>
	{
		private readonly int m_PacketID;
		private readonly OnPacketReceive<T> m_OnReceive;

		public PacketHandler(int packetID, OnPacketReceive<T> onReceive)
		{
			m_PacketID = packetID;
			m_OnReceive = onReceive;
		}

		public int PacketID
		{
			get { return m_PacketID; }
		}

		public OnPacketReceive<T> OnReceive
		{
			get { return m_OnReceive; }
		}
	}
	*/
	
	/// <summary>
	/// Specifies required methods for packet handlers.
	/// </summary>
	/// <typeparam name="Connection"></typeparam>
	public interface IPacketHandler<TConnection> where TConnection : Connection
	{
		/// <summary>
		/// Handles packet from connection.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		void Handle(TConnection conn, Packet packet);
	}

	/// <summary>
	/// A packet handler that runs other handlers based on their op.
	/// </summary>
	/// <typeparam name="Connection"></typeparam>
	public abstract class PacketHandler<TConnection> : IPacketHandler<TConnection> where TConnection : Connection
	{
		private Dictionary<int, PacketHandlerFunc> _handlers;

		/// <summary>
		/// A delegate used to handle a packet.
		/// </summary>
		/// <typeparam name="Connection"></typeparam>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		public delegate void PacketHandlerFunc(TConnection conn, Packet packet);

		/// <summary>
		/// Creates new packet handler.
		/// </summary>
		public PacketHandler()
		{
			this._handlers = new Dictionary<int, PacketHandlerFunc>();
		}

		/// <summary>
		/// Runs handler for packet's op if there is one.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		public void Handle(TConnection conn, Packet packet)
		{
			PacketHandlerFunc handler;

			lock (this._handlers)
			{
				this._handlers.TryGetValue(packet.Op, out handler);
			}

			if (handler == null)
			{
				this.OnUnknownPacket(conn, packet);
				return;
			}

			handler(conn, packet);
		}

		/// <summary>
		/// Called when there's no handler for an op.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		protected virtual void OnUnknownPacket(TConnection conn, Packet packet)
		{
			Log.Debug("PacketHandler: No handler found for '{0:X4}', {1}.\n{2}", packet.Op, Op.GetName(packet.Op), packet.ToString());
		}

		/// <summary>
		/// Registers handler for op.
		/// </summary>
		/// <param name="op"></param>
		/// <param name="handler"></param>
		public void Register(int op, PacketHandlerFunc handler)
		{
			lock (this._handlers)
			{
				this._handlers[op] = handler;
			}
		}

		/// <summary>
		/// Registers handler for op.
		/// </summary>
		/// <param name="op"></param>
		/// <param name="handler"></param>
		public void Register(int op, IPacketHandler<TConnection> handler)
		{
			lock (this._handlers)
			{
				this._handlers[op] = handler.Handle;
			}
		}

		/// <summary>
		/// Registers all methods of this class that have a packet handler attribute.
		/// </summary>
		public void RegisterMethods()
		{
			foreach (var method in this.GetType().GetMethods())
			{
				try
				{
					foreach (PacketHandlerAttribute attr in method.GetCustomAttributes(typeof(PacketHandlerAttribute), false))
					{
						var func = (PacketHandlerFunc)Delegate.CreateDelegate(typeof(PacketHandlerFunc), this, method);
						foreach (var op in attr.Ops)
						{
							this.Register(op, func);
						}
					}
				}
				catch (Exception ex)
				{
					Log.Error("Failed to register packet handler '{0}': {1}", method.Name, ex);
					CliUtil.Exit(1);
				}
			}
		}
	}

	/// <summary>
	/// Specifies ops that the packet handler can be used for.
	/// </summary>
	public class PacketHandlerAttribute : Attribute
	{
		/// <summary>
		/// Ops the handler can be used for.
		/// </summary>
		public int[] Ops { get; private set; }

		/// <summary>
		/// Creates new packet handler attribute.
		/// </summary>
		/// <param name="ops"></param>
		public PacketHandlerAttribute(params int[] ops)
		{
			this.Ops = ops;
		}
	}
}
