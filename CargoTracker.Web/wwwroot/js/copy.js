window.cargoTrackerCopyToClipboard = async function (text) {
    try {
        if (navigator && navigator.clipboard && navigator.clipboard.writeText) {
            await navigator.clipboard.writeText(text);
            return true;
        }
        // Fallback
        const ta = document.createElement('textarea');
        ta.value = text;
        ta.style.position = 'fixed';
        ta.style.left = '-1000px';
        document.body.appendChild(ta);
        ta.focus();
        ta.select();
        const ok = document.execCommand('copy');
        document.body.removeChild(ta);
        return ok;
    } catch (e) {
        console.error('copy failed', e);
        throw e;
    }
}

// Returns the client's timezone offset in minutes (same semantics as Date.getTimezoneOffset()).
// Positive values are minutes behind UTC, negative values are minutes ahead of UTC.
window.cargoTrackerGetTimezoneOffsetMinutes = function() {
    try {
        return new Date().getTimezoneOffset();
    } catch (e) {
        console.error('getTimezoneOffset failed', e);
        return 0; // Fallback to UTC
    }
};
