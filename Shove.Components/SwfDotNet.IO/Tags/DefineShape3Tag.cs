﻿/*
	SwfDotNet is an open source library for writing and reading 
	Macromedia Flash (SWF) bytecode.
	Copyright (C) 2005 Olivier Carpentier - Adelina foundation
	see Licence.cs for GPL full text!
		
	SwfDotNet.IO uses a part of the open source library SwfOp actionscript 
	byte code management, writted by Florian Krüsch, Copyright (C) 2004 .
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	General Public License for more details.
	
	You should have received a copy of the GNU General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
using System;
using System.IO;
using System.Xml;
using System.Collections;

using SwfDotNet.IO.Tags;
using SwfDotNet.IO.Tags.Types;
using SwfDotNet.IO.Utils;

namespace SwfDotNet.IO.Tags {
	
	/// <summary>
	/// DefineShape3Tag defines a transparent shape to be displayed.
	/// </summary>
	/// <remarks>
	/// <p>
	/// It extends the functionality of the DefineShape2Tag class by 
	/// supporting transparent colors.
	/// </p>
	/// <p>
	/// The shape defines a path containing a mix of straight and curved 
	/// edges and pen move actions. A path need not be contiguous. 
	/// When the shape is drawn the ShapeStyle object selects the line 
	/// and fill styles, from the respective array, to be used. ShapeStyle 
	/// objects can be defined in the shape at any time to change the 
	/// styles being used. The fill style used can either be an area of 
	/// pure color, a bitmap image or a gradient. The line style specifies 
	/// the color and thickness of the line drawn around the shape outline. 
	/// For both line and fill styles the selected style may be undefined, 
	/// allowing the shape to be drawn without an outline or left unfilled.
	/// </p>
	/// <p>
	/// This tag was introduced in Flash 3.
	/// </p>
	/// </remarks>
	public class DefineShape3Tag : DefineShape 
	{	
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="DefineShape3Tag"/> instance.
        /// </summary>
        public DefineShape3Tag()
        {
            this.shapeType = ShapeType.Shape3;
            this.versionCompatibility = 3;
            this._tagCode = (int)TagCodeEnum.DefineShape3;
        }

		/// <summary>
		/// Creates a new <see cref="DefineShape3Tag"/> instance.
		/// </summary>
		/// <param name="shapeId">Shape id.</param>
		/// <param name="rect">Rect.</param>
		/// <param name="shape">Shape.</param>
		public DefineShape3Tag(ushort shapeId, Rect rect, ShapeWithStyle shape)
			: base(shapeId, rect, shape)
		{
			this.shapeType = ShapeType.Shape3;
            this.versionCompatibility = 3;
            this._tagCode = (int)TagCodeEnum.DefineShape3;
		}

        #endregion

        #region Methods

		/// <summary>
		/// Serializes the specified writer.
		/// </summary>
		/// <param name="writer">Writer.</param>
		public override void Serialize(XmlWriter writer)
		{
			writer.WriteStartElement("DefineShape3Tag");
			base.Serialize(writer);
			writer.WriteEndElement();
		}

        #endregion
	}

}
