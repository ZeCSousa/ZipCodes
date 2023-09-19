 export function fetchWithTimeout(url, options, timeout) {
    // Create a new promise that will be resolved or rejected
    return new Promise((resolve, reject) => {
      // Start a timer that will reject the promise after the timeout
      const timer = setTimeout(() => {
        reject(new Error("Request timed out"));
      }, timeout);
  
      // Start the fetch request
      fetch(url, options)
        .then((response) => {
          // Clear the timer if the request succeeds
          clearTimeout(timer);
          // Resolve the promise with the response
          resolve(response);
        })
        .catch((error) => {
          // Clear the timer if the request fails
          clearTimeout(timer);
          // Reject the promise with the error
          reject(error);
        });
    });
  }