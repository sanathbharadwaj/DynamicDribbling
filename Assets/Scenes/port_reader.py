import serial   # Serial communication library
import pyautogui  # Simulating button pressing
import time  # For time related functions

import keyboard  # For controlling the keyboard

# Define the COM port settings
com_port = 'COM5'
baud_rate = 9600

com_port2 = 'COM6'


# Define the input ranges and corresponding keyboard inputs
# These ranges correspond to the ranges of values we expect from our serial input
# Each range is mapped to a keyboard input below
input_ranges = [
    (3, 6),
    (7, 10),
    (11, 1000),
    (-6, -3),
    (-10, -7),
    (-1000, -11)
]

# Keyboard inputs that correspond to the ranges above
keyboard_inputs = [
    'A',
    'B',
    'C',
    'D',
    'E',
    'F',
]


# Open the serial ports
ser = serial.Serial(com_port, baud_rate)
ser2 = serial.Serial(com_port2, baud_rate)

# Reading initial reference values from each serial port to get a stable value
for i in range(10):
    ref = int(float(ser.readline().strip()))


for i in range(10):
    ref2 = int(float(ser2.readline().strip()))

print('Ref: ', ref)
print('Ref: ', ref2)

# Endless loop to continually read data from both COM ports
while True:
    # Read the input from the COM ports
    data = ser.readline().strip()
    data2 = ser2.readline().strip()
    try:
        # Parse the input value
        value = int(float(data))
        value2 = int(float(data2))

        # Computing the differences from each value to the reference
        num = ref - value
        num2 = ref2 - value2

        # Summing up the differences
        result = num + num2
        print(result)

        # Find the corresponding range
        for i, (start, end) in enumerate(input_ranges):
            if start <= result <= end:
                # Press the corresponding keyboard key
                print('Pressed Key: ', keyboard_inputs[i])

                key_to_hold = keyboard_inputs[i]

                # Simulating a key press with hold duration of 0.2 seconds
                keyboard.press(key_to_hold)
                hold_duration = 0.2  # Adjust as needed
                time.sleep(hold_duration)
                keyboard.release(key_to_hold)
                break

    except ValueError:
        # Error handling for when data can't be parsed to a float
        print("Invalid input:", data)
