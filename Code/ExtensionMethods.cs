﻿/*
 * Copyright (c) 2011 Geoffrey Prytherch
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

using System;
using System.ComponentModel;

namespace OpticianDB.Extensions
{
	/// <summary>
	/// Description of ExtensionMethods.
	/// </summary>
	public static class GenericExtension
	{
		public static T? GetValueOrNull<T>(this string valueAsString)
			where T : struct
		{
			if (string.IsNullOrEmpty(valueAsString))
				return null;
			return (T) Convert.ChangeType(valueAsString, typeof(T));
		}
		public static T? GetValueOrNull<T>(this object valueAsObjectString)
			where T : struct
		{
			if (valueAsObjectString == null || string.IsNullOrEmpty(valueAsObjectString.ToString()))
				return null;
			return (T) Convert.ChangeType(valueAsObjectString.ToString(), typeof(T));
		}
	}
}