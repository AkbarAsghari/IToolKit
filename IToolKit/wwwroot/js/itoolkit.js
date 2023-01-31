
window.IToolKit = {
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
}

