Portable.Text.Encoding
======================

A Portable Implementation of System.Text.Encoding.

## Goals

The main goal of this project is to supply a portable alternative to System.Text.Encoding that can be used
from other PCL libraries.

Platforms such as Windows Phone currently do not provide support for text encodings other than a limited subset
of the Unicode encodings. This can be a real show-stopper when you need to work with legacy text encodings.

For example, while trying to make a PCL version of [MimeKit](https://github.com/jstedfast/MimeKit) available
for developers targetting Windows Phone, the biggest road block that I ran into was a lack of support for
charset conversion. While more and more mail software is moving toward using UTF-8, it's still common for
users to receive mail in other encodings. As you might imagine, a mail client that only supported receiving
mail that was encoded in UTF-8 would have very limited value to most users.

## Supported Text Encodings

Currently supported encodings include:
  * ASCII
  * Unicode (including UTF-8 and UTF-7)
  * Western Encodings
    * IBM437
    * IBM850
    * IBM860
    * IBM861
    * IBM862
    * IBM863
    * IBM865
    * ISO-8859-1
    * ISO-8859-2
    * ISO-8869-3
    * ISO-8859-7
    * ISO-8859-15
    * Windows-1250
    * Windows-1252
    * Windows-1253
    * Macintosh and Mac-Icelandic
  * Middle Eastern Encodings
    * ISO-8859-6
    * ISO-8859-8
    * ISO-8859-9
    * Windows-1254
    * Windows-1255
    * Windows-1256
    * Windows-38598
  * Chinese/Japanese/Korean Encodings
    * Big5
    * EUC-JP
    * EUC-KR
    * GB2312
    * GB18030
    * ISO-2022-JP
    * SHIFT-JIS
    * UHC
  * Other Encodings
    * ISO-8859-4
    * ISO-8859-5
    * KOI8-R
    * KOI8-U
    * Windows-874
    * Windows-1251
    * Windows-1257
    * Windows-1258
    * And many more...

## TODO

Add a few more optionally-included assemblies for whatever other encodings that may be desired.

## License Information

Portable.Text.Encoding is Copyright (C) 2014 Xamarin Inc. and is licensed under the MIT license:

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

## Installing via NuGet

The easiest way to install Portable.Text.Encoding is via 
[NuGet](https://www.nuget.org/packages/Portable.Text.Encoding/).

In Visual Studio's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console),
simply enter the following command:

    Install-Package Portable.Text.Encoding

## Building

Just open up Portable.Text.Encoding.sln in your favorite IDE (Visual Studio, Xamarin Studio, SharpDevelop, etc) and hit "Build", it's that easy!

## Contributing

The first thing you'll need to do is fork Portable.Text.Encoding to your own GitHub repository. Once you do that,

    git clone git@github.com/<your-account>/Portable.Text.Encoding.git

Now you are ready to start hacking away on the code. When you're satisfied with your set of patches, commit
them to your GitHub fork and then send me a Pull Request and I'll review and merge your changes into the
official repo.

### Adding Support for Other Text Encodings

So far, all of the code has been taken directly from [Mono](https://github.com/mono/mono) and it should be fairly
straight-forward to "port" the [I18N](https://github.com/mono/mono/tree/master/mcs/class/I18N) assemblies over to
Portable.Text.Encoding.

I think the best coarse of action is to follow the same overall design of the I18N assemblies - in other words: 
create a new PCL project/assembly for each "region" (West, CJK, MidEast, Rare, Other). Once you've added all the
sources (and tables for those that have them) and changed the namespace from `System.Text` to `Portable.Text`,
just try building. If there aren't any errors, you're done!

## Reporting Bugs

Have a bug or a feature request? [Please open a new issue](https://github.com/jstedfast/Portable.Text.Encoding/issues).

Before opening a new issue, please search for existing issues to avoid submitting duplicates.

## Documentation

There realistically doesn't need to be any real API documentation as the API is exactly the same as
System.Text.Encoding API, but I'm open to contributions in this area.
