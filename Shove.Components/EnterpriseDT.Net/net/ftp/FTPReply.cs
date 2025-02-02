// edtFTPnet
// 
// Copyright (C) 2004 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// Bug fixes, suggestions and comments should posted on 
// http://www.enterprisedt.com/forums/index.php
// 
// Change Log:
// 
// $Log: FTPReply.cs,v $
// Revision 1.6  2008-08-21 00:45:33  hans
// MalformedReplyException now thrown when reply is corrupted.
//
// Revision 1.5  2008-02-04 03:13:20  bruceb
// constructors public
//
// Revision 1.4  2004/11/05 20:00:28  bruceb
// cleaned up namespaces
//
// Revision 1.3  2004/10/29 09:41:44  bruceb
// removed /// in file header
//
//
//

using System;

namespace EnterpriseDT.Net.Ftp
{
	/// <summary>  Encapsulates the FTP server reply
	/// 
	/// </summary>
	/// <author>       Bruce Blackshaw
	/// </author>
	/// <version>      $Revision: 1.6 $
	/// </version>
	public class FTPReply
	{
		/// <summary>  Getter for reply code
		/// 
		/// </summary>
		/// <returns> server's reply code
		/// </returns>
		virtual public string ReplyCode
		{
			get
			{
				return replyCode;
			}
			
		}
		/// <summary>  Getter for reply text
		/// 
		/// </summary>
		/// <returns> server's reply text
		/// </returns>
		virtual public string ReplyText
		{
			get
			{
				return replyText;
			}
			
		}
		/// <summary> Getter for reply data lines
		/// 
		/// </summary>
		/// <returns> array of data lines returned (if any). Null
		/// if no data lines
		/// </returns>
		virtual public string[] ReplyData
		{
			get
			{
				return data;
			}
			
		}
		
		/// <summary>  Reply code</summary>
		private string replyCode;
		
		/// <summary>  Reply text</summary>
		private string replyText;
		
		/// <summary> Lines of data returned, e.g. FEAT</summary>
		private string[] data;
		
		/// <summary>  Constructor. Only to be constructed
		/// by this package, hence package access
		/// 
		/// </summary>
		/// <param name="replyCode"> the server's reply code
		/// </param>
		/// <param name="replyText"> the server's reply text
		/// </param>
		public FTPReply(string replyCode, string replyText)
            : this(replyCode, replyText, null)
		{
		}
		
		
		/// <summary>  Constructor. Only to be constructed
		/// by this package, hence package access
		/// 
		/// </summary>
		/// <param name="replyCode"> the server's reply code
		/// </param>
		/// <param name="replyText"> the server's full reply text
		/// </param>
		/// <param name="data">      data lines contained in reply text
		/// </param>
        public FTPReply(string replyCode, string replyText, string[] data)
		{
            foreach (char ch in replyCode)
                if (!Char.IsDigit(ch))
                    throw new MalformedReplyException("Malformed FTP reply: " + replyCode);

			this.replyCode = replyCode;
			this.replyText = replyText;
			this.data = data;
		}
	}
}
