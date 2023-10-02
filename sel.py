import time
from selenium import webdriver
from selenium.webdriver.common.desired_capabilities import DesiredCapabilities

# Wait for 10 seconds
time.sleep(10)

# Define the URL of the Selenium Server running in your Docker container
selenium_server_url = "http://localhost:4444/wd/hub"

chrome_options = webdriver.ChromeOptions()
driver = webdriver.Remote(
    command_executor='http://localhost:4444/wd/hub',
    options=chrome_options
)

# Open a website and perform actions
website_url = 'http://192.168.53.131:4200/'
driver.get(website_url)

# Check if the website is accessible by verifying the page title
expected_title = 'App'
actual_title = driver.title

if expected_title in actual_title:
    print(f"The website '{website_url}' is accessible.")
else:
    print(f"The website '{website_url}' is not accessible.")

# Close the browser
#driver.quit()
