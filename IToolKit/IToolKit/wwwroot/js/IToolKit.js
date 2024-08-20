window.IToolKit = {
    //Hash
    Hash: {
        MD5: function (message) {
            return CryptoJS.MD5(message).toString();
        },
        SHA1: function (message) {
            return CryptoJS.SHA1(message).toString();
        },
        SHA256: function (message) {
            return CryptoJS.SHA256(message).toString();
        },
        SHA384: function (message) {
            return CryptoJS.SHA384(message).toString();
        },
        SHA512: function (message) {
            return CryptoJS.SHA512(message).toString();
        }
    },

    //HMAC
    HMAC: {
        MD5: function (message, secret) {
            return CryptoJS.HmacMD5(message, secret).toString();
        },
        SHA1: function (message, secret) {
            return CryptoJS.HmacSHA1(message, secret).toString();
        },
        SHA256: function (message, secret) {
            return CryptoJS.HmacSHA256(message, secret).toString();
        },
        SHA512: function (message, secret) {
            return CryptoJS.HmacSHA512(message, secret).toString();
        }
    },
    //Cipher
    Cipher: {
        AES: {
            Encrypt: function (message, secret) {
                console.log(message);
                console.log(secret);
                return CryptoJS.AES.encrypt(message, secret).toString();
            },
            Decrypt: function (encrypted, secret) {
                return CryptoJS.AES.decrypt(encrypted, secret).toString(CryptoJS.enc.Utf8);
            }
        }
    },
    //Cache
    Cache: {
        Clear: function () {
            caches.keys().then(function (names) {
                for (let name of names)
                    caches.delete(name);
            });
        }
    },
    //Location
    Location: {
        Reload: function () {
            location.reload();
        }
    },
    //Converts
    Convert: {
        ToHex: function (input) {
            return (new BigNumber(input)).toString(16); 
        },
        ToOct: function (input) {
            return (new BigNumber(input)).toString(8);
        },
        ToBin: function (input) {
            return (new BigNumber(input)).toString(2);
        },
    }
}

