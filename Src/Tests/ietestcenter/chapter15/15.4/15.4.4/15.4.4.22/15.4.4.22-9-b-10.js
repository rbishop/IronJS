/// Copyright (c) 2009 Microsoft Corporation 
/// 
/// Redistribution and use in source and binary forms, with or without modification, are permitted provided
/// that the following conditions are met: 
///    * Redistributions of source code must retain the above copyright notice, this list of conditions and
///      the following disclaimer. 
///    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and 
///      the following disclaimer in the documentation and/or other materials provided with the distribution.  
///    * Neither the name of Microsoft nor the names of its contributors may be used to
///      endorse or promote products derived from this software without specific prior written permission.
/// 
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
/// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
/// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
/// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
/// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
/// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
/// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
/// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


ES5Harness.registerTest({

    id: "15.4.4.22-9-b-10",

    path: "TestCases/chapter15/15.4/15.4.4/15.4.4.22/15.4.4.22-9-b-10.js",

    description: "Array.prototype.reduceRight - deleting property of prototype in step 8 causes deleted index property not to be visited on an Array-like Object",

    test: function testcase() {

        var accessed = false;
        var testResult = true;

        function callbackfn(preVal, val, idx, obj) {
            accessed = true;
            if (idx === 3) {
                testResult = false;
            }
        }

        var obj = { 2: 2, length: 20 };

        Object.defineProperty(obj, "5", {
            get: function () {
                delete Object.prototype[3];
                return 0;
            },
            configurable: true
        });

        try {
            Object.prototype[3] = 1;
            Array.prototype.reduceRight.call(obj, callbackfn);
            return testResult && accessed;
        } finally {
            delete Object.prototype[3];
        }
    },

    precondition: function prereq() {
        return fnExists(Array.prototype.reduceRight) && fnExists(Object.defineProperty) && fnSupportsArrayIndexGettersOnObjects();
    }

});
