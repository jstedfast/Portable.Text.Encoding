Portable.Text.Encoding
======================

A Portable Implementation of System.Text.Encoding.

## Goals

The main goal of this project is to supply a portable alternative to System.Text.Encoding that can be used
from other PCL libraries.

Platforms such as Silverlight and Windows Phone currently do not provide support for text encodings other
than a limited subset of the Unicode encodings. This can be a real show-stopper when you need to work with
legacy text encodings.

For example, while trying to make a PCL version of [MimeKit](https://github.com/jstedfast/MimeKit) available
for developers targetting Windows Phone, the biggest road block that I ran into was a lack of support for
charset conversion. While more and more mail software is moving toward using UTF-8, it's still common for
users to receive mail in other encodings. As you might imagine, a mail client that only supported receiving
mail that was encoded in UTF-8 would have very limited value to most users.

## Supported Text Encodings

So far, only ASCII, Latin1 (aka ISO-8859-1) and the Unicode (including UTF-8 and UTF-7) encodings are supported.

## TODO

Add a few more optionally-included assemblies for other Western encodings, CJK, Middle Eastern, and whatever
other encodings that may be desired.
