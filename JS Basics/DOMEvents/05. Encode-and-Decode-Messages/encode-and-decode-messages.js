document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('#encode button').addEventListener('click', encodeMessage);
    document.querySelector('#decode button').addEventListener('click', decodeMessage);

    function encodeMessage(e) {
        e.preventDefault();

        const msgToEncode = e.target.parentElement.querySelector('textarea').value;
        let encodedMsg = '';
        for (let i = 0; i < msgToEncode.length; i++) {
            encodedMsg = encodedMsg.concat(String.fromCharCode(msgToEncode.charCodeAt(i) + 1));
        }

        e.target.parentElement.querySelector('textarea').value = '';
        document.querySelector('#decode textarea').value = encodedMsg;
    }

    function decodeMessage(e) {
        e.preventDefault();

        const encodedMsg = e.target.parentElement.querySelector('textarea').value;
        let decodedMsg = '';
        for (let i = 0; i < encodedMsg.length; i++) {
            decodedMsg = decodedMsg.concat(String.fromCharCode(encodedMsg.charCodeAt(i) - 1));
        }

        e.target.parentElement.querySelector('textarea').value = decodedMsg;
    }
}