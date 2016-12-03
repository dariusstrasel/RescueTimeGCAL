# Title: RescueTimeGCALSync
# Objective: Get RescueTime time tracking data and sync with Google Calendar
# TODO: Write wrapper functions to interact with API data feed (Sort of done.)
# TODO:

import requests
import requests_cache
from requests.auth import HTTPBasicAuth
import json
import sys

class API_Results:

    def __init__(self):
        API_Results.install_cache('activity_results')
        API_Results.read_api_key()
        pass

    def install_cache(name):
        requests_cache.install_cache(name)

    def read_api_key():
        secrets_filename = 'secret_keys'
        api_keys = {}
        try:
            with open(secrets_filename, 'r') as f:
                try:
                    api_keys = json.loads(f.read())
                    return api_keys['rescuetime_secret']
                except json.JSONDecodeError:
                    print("Add API key to secrets file.")
        except FileNotFoundError:
            print("No secrets file detected. Creating new one...")
            new_file = open(secrets_filename, 'w')

    def get_api_data(perspective, restrict_kind, interval, restrict_begin, restrict_end, format):
        print(">>>get_api_data")
        # highlight_feed = 'https://www.rescuetime.com/anapi/highlights_feed?key='
        # data_feed = 'https://www.rescuetime.com/anapi/data?key='
        api_url = 'https://www.rescuetime.com/anapi/data'
        api_key = read_api_key()
        parameters = {'key': api_key,
                      'perspective': perspective,
                      'restrict_kind': restrict_kind,
                      'interval': interval,
                      'restrict_begin': restrict_begin,
                      'restrict_end': restrict_end,
                      'format': format}
        get_results = requests.get(api_url, params=parameters)
        results = get_results.json()
        api_activity_results = results['rows']
        return api_activity_results


def return_result_datetime(row_result_list):
    result_output = []
    for row in row_result_list:
        result_output.append(return_results_datetime(row))
    return result_output


def return_results_datetime(row_result_list):
    date_index = 0
    return row_result_list[date_index]


def pivot_activity_by_datetime(activities, datetimes):
    result_output = []
    datetime_index = 0
    activity_name_index = 3
    activity_timespent_index = 1
    for index_of_datetime, input_datetime in enumerate(datetimes):
        result_output.append({input_datetime: []})  # creates dictionary with datetime key and empty value
        for activity in activities:
            if activity[datetime_index] == input_datetime:
                # Appends activity_name to datetime key-value, if it matches the current date iterator
                result_output[index_of_datetime][input_datetime].append({activity[activity_name_index]: activity[activity_timespent_index]})
    return result_output


def return_datetime_list(list):
    result_output = []
    print(list)
    for index, item in enumerate(list):
        print(str(item))
        result.append(item.values())
    return result


def return_greatest_time(input):
    return max(input)


def argument_handler():
    for argument in sys.argv:
        print('>>>argument: ' + argument)
        if argument == 'pass':
            pass
        if argument == 'refresh':
            print(get_api_data('interval','activity','minute','2016-11-03','2016-11-03','json'))


# list_of_dates = return_result_datetime(api_activity_results)

# activities__ = pivot_activity_by_datetime(api_activity_results, list_of_dates)


# print(len(list_of_activities))
# print(list_of_activities[195])

# print(get_results.json())

# for index, item in enumerate(list_of_activities):
#     print(str(index) + str(item))

# print(list_of_activities)

# print(list_of_activities)

# return_time_list(list_of_activities)

# print(aggregate_rows(results['rows']))

if __name__ == '__main__':
    install_cache()

    # argument_handler()