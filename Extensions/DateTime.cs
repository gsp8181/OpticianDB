﻿// 
//  Copyright (c) 2011 Geoffrey Prytherch
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy of  this
//  software and associated documentation files (the "Software"), to deal in the Software
//  without restriction, including without limitation the rights to use, copy, modify, merge,
//  publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
//  to whom the Software is furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in all copies or
//  substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//  PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//  FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
//  OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.
//  
using System;

namespace OpticianDB.Extensions
{
    /// <summary>
    ///   Extension methods for the <see cref = "System.DateTime" /> class
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///   An extension method that determines whether the given time is in the future.
        /// </summary>
        /// <param name = "value">The given date and time.</param>
        /// <returns><c>true</c> if the given date and time is in the future; Otherwise, <c>false</c></returns>
        public static bool InFuture(this DateTime value)
        {
            return (value.Ticks > DateTime.Now.Ticks);
        }

        /// <summary>
        ///   An extension method that determines whether the given time is in the past.
        /// </summary>
        /// <param name = "value">The given date and time.</param>
        /// <returns><c>true</c> if the given date and time is in the past; Otherwise, <c>false</c></returns>
        public static bool InPast(this DateTime value)
        {
            return (value.Ticks < DateTime.Now.Ticks);
        }

        /// <summary>
        ///   An extension method that determines whether the given date is in the future.
        /// </summary>
        /// <param name = "value">The given date.</param>
        /// <returns><c>true</c> if the given date is in the future; Otherwise, <c>false</c></returns>
        public static bool DateInFuture(this DateTime value) //TODO: rejig
        {
            if (value.Date.Ticks <= DateTime.Now.Date.Ticks)
                return false;
            return true;
        }

        /// <summary>
        ///   An extension method that determines whether the given date is in the past.
        /// </summary>
        /// <param name = "value">The given date.</param>
        /// <returns><c>true</c> if the given date is in the past; Otherwise, <c>false</c></returns>
        public static bool DateInPast(this DateTime value)
        {
            if (value.Date.Ticks >= DateTime.Now.Date.Ticks)
                return false;
            return true;
        }
    }
}