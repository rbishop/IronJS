// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S7.9_A6.1_T3;
 * @section: 7.9, 12.6.3;
 * @assertion: Check For Statement for automatic semicolon insertion; 
 * @description: for (\n two semicolons \n);
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S7.9_A6.1_T3",

path: "TestCases/07_Lexical_Conventions/7.9_Automatic_Semicolon_Insertion/S7.9_A6.1_T3.js",

assertion: "Check For Statement for automatic semicolon insertion",

description: "for (\\n two semicolons \\n)",

test: function testcase() {
   //CHECK#1
for(
    ;;
) {
  break;
}

 }
});
