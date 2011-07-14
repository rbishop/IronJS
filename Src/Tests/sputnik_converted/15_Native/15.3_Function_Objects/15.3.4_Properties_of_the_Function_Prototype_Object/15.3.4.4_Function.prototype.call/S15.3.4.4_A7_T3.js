// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
* @name: S15.3.4.4_A7_T3;
* @section: 15.3.4.4;
* @assertion: Function.prototype.call can't be used as [[create]] caller;
* @description: Checking if creating "new Function.call" fails;
*/


// Converted for Test262 from original Sputnik source

ES5Harness.registerTest( {
id: "S15.3.4.4_A7_T3",

path: "TestCases/15_Native/15.3_Function_Objects/15.3.4_Properties_of_the_Function_Prototype_Object/15.3.4.4_Function.prototype.call/S15.3.4.4_A7_T3.js",

assertion: "Function.prototype.call can\'t be used as [[create]] caller",

description: "Checking if creating \"new Function.call\" fails",

test: function testcase() {
   try {
  var obj = new Function.call;
  $ERROR('#1: Function.prototype.call can\'t be used as [[create]] caller');
} catch (e) {
  if (!(e instanceof TypeError)) {
  	$ERROR('#1.1: Function.prototype.call can\'t be used as [[create]] caller');
  }
}

 }
});
