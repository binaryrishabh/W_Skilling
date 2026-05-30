// Simple confirmation before adding item
document.addEventListener('DOMContentLoaded', function() {
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function(e) {
            console.log('Form submitted at: ' + new Date());
        });
    }
});