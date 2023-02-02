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
    }
}

