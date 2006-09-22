// Copyright 2006 Alp Toker <alp@atoker.com>
// This software is made available under the MIT License
// See COPYING for details

using System;
//using GLib;
//using Gtk;
using NDesk.DBus;
using NDesk.GLib;
using org.freedesktop.DBus;

namespace NDesk.DBus
{
	//FIXME: this API needs review and de-unixification
	public static class DApplication
	{
		static bool Dispatch (IOChannel source, IOCondition condition, IntPtr data)
		{
			//Console.Error.WriteLine ("Dispatch " + source.UnixFd + " " + condition);
			connection.Iterate ();
			//Console.Error.WriteLine ("Dispatch done");

			return true;
		}

		static Connection connection = null;
		public static Connection Connection
		{
			get {
				if (connection == null)
					Init ();

				return connection;
			}
		}

		//this will need to change later, but is needed for now
		static Bus sessionBus = null;
		public static Bus SessionBus
		{
			get {
				if (sessionBus == null) {
					sessionBus = Connection.GetObject<Bus>("org.freedesktop.DBus", new ObjectPath("/org/freedesktop/DBus"));
					sessionBus.Hello ();
				}

				return sessionBus;
			}
		}

		[Obsolete]
		public static void Init ()
		{
			connection = new Connection ();

			IOChannel channel = new IOChannel ((int)connection.SocketHandle);
			IO.AddWatch (channel, IOCondition.In, Dispatch);
		}
	}
}
