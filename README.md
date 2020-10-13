## Task description

Implement a [TranslateToPigLatin]() method that translates from English to [Pig Latin Language](https://en.wikipedia.org/wiki/Pig_Latin). It obeys a few simple following rules:
1. If a word begins with a vowel sound, add an `"yay"` sound to the end of the word.
1. If a word begins with a consonant sound, move it to the end of the word and then add an `"ay"` sound to the end of the word. Consonant sounds can be made up of multiple consonants, a.k.a. a consonant cluster (e.g. `"chair" -> "airchay"`).
1. If a word starts with a consonant sound followed by `"qu"`, move it to the end of the word, and then add an `"ay"` sound to the end of the word (e.g. `"square" -> "aresquay"`).
1. If a word contains a `"y"` after a consonant cluster or as the second letter in a two letter word it makes a vowel sound (e.g. `"rhythm" -> "ythmrhay"`, `"my" -> "ymay"`).    
The task definition is given in the XML-comments for the method.