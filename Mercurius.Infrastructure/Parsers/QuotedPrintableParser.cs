/*
*
* Third-party parser developed by 7Clouds
* https://github.com/petrohi/Stratosphere.Imap
*
**********************************************
* License: The MIT License (MIT)
* Copyright (c) 2010 7Clouds
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*/

using System;
using System.Text;

namespace Mercurius.Infrastructure.Parsers
{
    public static class QuotedPrintableParser
    {
        public static string Parse(string input)
        {
            return Parse(Encoding.UTF8, input, 0, false);
        }

        public static string Parse(Encoding enc, string input)
        {
            return Parse(enc, input, 0, false);
        }

        private static string Parse(Encoding enc, string input, int startPosition, bool skipQuestionEquals)
        {
            var workingBytes = Encoding.ASCII.GetBytes(input);

            var i = startPosition;
            var outputPos = i;

            while (i < workingBytes.Length)
            {
                var currentByte = workingBytes[i];
                var peekAhead = new char[2];
                switch (currentByte)
                {
                    case (byte) '=':
                        var canPeekAhead = i < workingBytes.Length - 2;

                        if (!canPeekAhead)
                        {
                            workingBytes[outputPos] = workingBytes[i];
                            ++outputPos;
                            ++i;
                            break;
                        }

                        var skipNewLineCount = 0;
                        for (var j = 0; j < 2; ++j)
                        {
                            var c = (char) workingBytes[i + j + 1];
                            if ('\r' == c || '\n' == c)
                            {
                                ++skipNewLineCount;
                            }
                        }

                        if (skipNewLineCount > 0)
                        {
                            i += 1 + skipNewLineCount;
                        }
                        else
                        {
                            try
                            {
                                peekAhead[0] = (char) workingBytes[i + 1];
                                peekAhead[1] = (char) workingBytes[i + 2];

                                var decodedByte = Convert.ToByte(new string(peekAhead, 0, 2), 16);
                                workingBytes[outputPos] = decodedByte;

                                ++outputPos;
                                i += 3;
                            }
                            catch (Exception)
                            {
                                i += 1;
                            }
                        }
                        break;

                    case (byte) '?':
                        if (skipQuestionEquals && workingBytes[i + 1] == (byte) '=')
                        {
                            i += 2;
                        }
                        else
                        {
                            workingBytes[outputPos] = workingBytes[i];
                            ++outputPos;
                            ++i;
                        }
                        break;

                    default:
                        workingBytes[outputPos] = workingBytes[i];
                        ++outputPos;
                        ++i;
                        break;
                }
            }

            var output = string.Empty;

            var numBytes = outputPos - startPosition;
            if (numBytes > 0)
            {
                output = enc.GetString(workingBytes, startPosition, numBytes);
            }

            return output;
        }
    }
}