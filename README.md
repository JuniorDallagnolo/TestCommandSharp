# TestCommandSharp
Simple command line program that converts parameters into something else

Accepts any number of parameters on the command line.
Each parameter should be of the form <number><string> where <number> is a single digit from 0 to 9 and <string> is a lower case string composed of the characters from a to z with length of at least 1.
Each parameter should be processed in the following way with the output from each parameter printed on its own line:
The digit indicates how many character positions each character should be increased by, with wraparound from "z" to "a".
The modified string, without its digit prefix, should be printed to STDOUT.
Example parameters and output (the quotes are not part of the input or output):

"0apple" -> "apple"
"2bed" -> "dgf"

"8hello" -> "pmttw"
"5zoo" -> "ett"

# Use the IDE or even the command line to pass the parameters
